using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.Author;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.MVC.Controllers;

public class AuthorController(IAuthorService authorService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var authors = await authorService.GetAuthors();
        return View(authors);
    }


    public async Task<IActionResult> Searched()
    {
        if (TempData["Authors"] != null)
        {
            var authors = JsonConvert.DeserializeObject<List<AuthorVM>>((string)TempData["Authors"]!);
            return View("Index", authors);
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Search(AuthorSearchOptionsVM options)
    {
        ViewBag.SearchController = "Author";
        List<AuthorVM> authors = new List<AuthorVM>();
        
        if (!string.IsNullOrEmpty(options.Name))
        {
            ViewBag.SearchExceptionMessage = "There is no such author in our library :(";
            var authorsByName = await authorService.GetAuthorsByName(options.Name);
            authors.AddRange(authorsByName);
        }
        
        if (!string.IsNullOrEmpty(options.Nationality))
        {
            ViewBag.SearchExceptionMessage = "There is no such author's nationality in our library :(";
            var authorsByNationality = await authorService.GetAuthorsByNationality(options.Nationality);
            authors.AddRange(authorsByNationality);
        }

        if (options.Birthday.HasValue)
        {
            ViewBag.SearchExceptionMessage = "There is no such author with that birthday in our library :(";
            var authorsByBirthday = await authorService.GetAuthorsByBirthday(options.Birthday.Value);
            authors.AddRange(authorsByBirthday);
        }

        if (authors.Count == 0)
            return RedirectToAction("Index");

        return View("Index", authors.DistinctBy(x => x.Id));
    }

    public async Task<IActionResult> Details(int id)
    {
        var author = await authorService.GetAuthor(id);
        return View(author);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateAuthorVM author)
    {
        try
        {
            var response = await authorService.UpdateAuthor(author);

            if (response.Successs)
                return RedirectToAction("Details", new {id = author.Id});
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction("Index", "Author");
    }


}
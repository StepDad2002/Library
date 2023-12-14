using Library.MVC.Contracts;
using Library.MVC.Models.Book;
using Library.MVC.Models.Shelf;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers;

public class ShelfController(IShelfService shelfService, IBookService bookService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var shelves = await shelfService.GetShelves();
        return View(shelves);
    }

    public async Task<IActionResult> SearchByName(string name)
    {
        var shelves = await shelfService.GetShelves(name);
        return View("Index", shelves);
    }

    public async Task<IActionResult> Details(int id)
    {
        var shelf = await shelfService.GetShelf(id);
        var books = await bookService.GetBooks();
        var allBooks = new List<BookListVM>();
        foreach (var bookListVm in books)
        {
            if (shelf.Books.Any(x => x.Id == bookListVm.Id))
                continue;
            allBooks.Add(bookListVm);
        }

        ViewBag.AllBooks = allBooks.Select(x => new { x.Id, x.Title });
        return View(shelf);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditShelf(UpdateShelfVM shelfToUpdate)
    {
        try
        {
            var response = await shelfService.UpdateShelf(shelfToUpdate);

            if (response.Successs)
                return RedirectToAction(nameof(Details), new { id = shelfToUpdate.Id });
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("Index");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PutBooksInShelf(int id, ICollection<int> bookIds)
    {
        try
        {
            var response = await shelfService.UpdateShelfBooks(id, bookIds);

            if (response.Successs)
                return RedirectToAction(nameof(Details), new {id});
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("Index");
    }


    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await shelfService.DeleteShelf(id);

            if (response.Successs)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction(nameof(Details), new { id });
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateShelfVM shelf)
    {
        try
        {
            var response = await shelfService.CreateShelf(shelf);

            if (response.Successs)
                return RedirectToAction(nameof(Details), new { id = response.Data });
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View(shelf);
    }
}
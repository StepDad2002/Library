using Library.MVC.Contracts;
using Library.MVC.Models.Book;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.MVC.Controllers;

public class BookController(IBookService bookService, IShelfService shelfService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var books = await bookService.GetBooks();
        return View(books);
    }


    public async Task<IActionResult> Searched()
    {
        if (TempData["Books"] != null)
        {
            var books = JsonConvert.DeserializeObject<List<BookListVM>>((string)TempData["Books"]!);
            return View("Index", books);
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Search(BookSearchOptionsVM options)
    {
        ViewBag.SearchController = "Book";
        List<BookListVM> books = new List<BookListVM>();
        try
        {
            if (!string.IsNullOrEmpty(options.Isbn))
            {
                ViewBag.SearchExceptionMessage = "There is no such ISBN in our library :(";
                var book = await bookService.GetBookByIsbn(options.Isbn);
                if (book is null)
                    return View("_ErrorPage");
                return RedirectToAction("Details", book);
            }


            if (!string.IsNullOrEmpty(options.Category))
            {
                ViewBag.SearchExceptionMessage = "There is no such category for book in our library :(";
                books.AddRange(await bookService.GetBooksByCategory(options.Category));
            }

            if (!string.IsNullOrEmpty(options.Genre))
            {
                ViewBag.SearchExceptionMessage = "There is no such genre for book in our library :(";
                books.AddRange(await bookService.GetBooksByGenre(options.Genre));
            }

            if (!string.IsNullOrEmpty(options.Language))
            {
                ViewBag.SearchExceptionMessage = "There is no such language for book in our library :(";
                books.AddRange(await bookService.GetBooksByLanguage(options.Language));
            }

            if (!string.IsNullOrEmpty(options.Title))
            {
                ViewBag.SearchExceptionMessage = "There is no such book title in our library :(";
                books.AddRange(await bookService.GetBooksByTitle(options.Title));
            }

            if (options.PublicationDate.HasValue)
            {
                ViewBag.SearchExceptionMessage = "There is no book published on that date in our library :(";
                books.AddRange(await bookService.GetBooksByPublicationDate(options.PublicationDate.Value));
            }
        }
        catch (Exception ex)
        {
            return View("_ErrorPage");
        }

        if (books.Count == 0)
            return View("_ErrorPage");

        return View("Index", books.DistinctBy(x => x.Id));
    }

    public async Task<IActionResult> Details(int id)
    {
        var shelves = await shelfService.GetShelves();
        ViewBag.Shelves = shelves.Select(x => new { x.Id, x.Name });
        var book = await bookService.GetBook(id);
        return View(book);
    }


    [HttpPost]
    public async Task<IActionResult> Edit([FromBody] UpdateBookVM bookToUpdate)
    {
        try
        {
            var response = await bookService.UpdateBook(bookToUpdate);
            if (response.Successs)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Details", new { id = bookToUpdate.Id }) });
            }

            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        string errorContent = JsonConvert.SerializeObject(ModelState.Values
            .Where(x => x.Errors.Count > 0)
            .SelectMany(x => x.Errors.Select(x => x.ErrorMessage)));

        return Content(errorContent);
    }

    [HttpPost]
    public async Task<IActionResult> ReplaceBook(int id, int shelfId)
    {
        try
        {
            var response = await bookService.ReplaceBook(id, shelfId);
            if (response.Successs)
            {
                return RedirectToAction("Details", new{id});
            }

            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }


        return RedirectToAction("Details", new{id});
    }


    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await bookService.DeleteBook(id);

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
        var shelves = await shelfService.GetShelves();
        ViewBag.Shelves = shelves.Select(x => new { x.Id, x.Name });
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookVM book)
    {
        try
        {
            var response = await bookService.CreateBook(book);

            if (response.Successs)
                return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        var shelves = await shelfService.GetShelves();
        ViewBag.Shelves = shelves.Select(x => new { x.Id, x.Name });
        return View(book);
    }
}
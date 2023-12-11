using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Library.MVC.Controllers;

public class HomeController(IBookService bookService, IAuthorService authorService,
    IPublisherService publisherService, IMemoryCache cache) : Controller
{
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        var fromCacheTop = await cache.GetOrCreateAsync("topEntities", async x =>
        {
            BookAuthorPublisherWrapper model = new BookAuthorPublisherWrapper()
            {
                Books = await bookService.GetTopBooks(10),
                Publishers = await publisherService.GetTopPublishers(10),
                Authors = await authorService.GetTopAuthors(10)
            };
            return model;
        });


        return View(fromCacheTop);
    }

    public async Task<IActionResult> Search(string query)
    {
        var books = await bookService.GetBooksByTitle(query);
        
        if (books.Count > 0)
        {
            TempData["Books"] = JsonConvert.SerializeObject(books);
            return RedirectToAction("Searched", "Book" );
        }
        
        var authors = await authorService.GetAuthorsByName(query);
        
        if (authors.Count > 0)
        {
            TempData["Authors"] = JsonConvert.SerializeObject(authors);
            return RedirectToAction("Searched", "Author");
        }

        try
        {
            var publisher = await publisherService.GetPublisher(query);
            if (publisher is not null)
            {
                TempData["Publisher"] = JsonConvert.SerializeObject(publisher);
                return RedirectToAction("Searched", "Publisher", new {publisher});
            }
        }
        catch (ApiException e)
        {
            return RedirectToAction("Index");
        }
        
        

        return RedirectToAction("Index");
    }
}
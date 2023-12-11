using Library.MVC.Contracts;
using Library.MVC.Models.Publisher;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.MVC.Controllers;

public class PublisherController(IPublisherService publisherService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var publishers = await publisherService.GetPublishers();
        return View(publishers);
    }

    public async Task<IActionResult> Details(int id)
    {
        var publisher = await publisherService.GetPublisher(id);
        return View(publisher);
    }
    
    public async Task<IActionResult> SearchByName(string name)
    {
        var publisher = await publisherService.GetPublisher(name);
        return View("Details",publisher);
    }
    
    public async Task<IActionResult> Searched()
    {
        if (TempData["Publisher"] != null)
        {
            var publisher = JsonConvert.DeserializeObject<PublisherVM>((string)TempData["Publisher"]!);
            return View("Details", publisher);
        }

        return RedirectToAction("Index");
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Edit(UpdatePublisherVM publisherToUpdate)
    {
        try
        {
            var response = await publisherService.UpdatePublisher(publisherToUpdate);

            if (response.Successs)
                return RedirectToAction(nameof(Details), publisherToUpdate.Id);
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View(publisherToUpdate);
    }
}
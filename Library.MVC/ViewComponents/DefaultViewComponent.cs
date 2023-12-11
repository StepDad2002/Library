using Library.MVC.Models.Author;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.ViewComponents;

public class DefaultViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}


using Library.MVC.Contracts;
using Library.MVC.Models.FinePayment;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers;

public class FinePaymentController(IFinePaymentService finePaymentService) : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
    
    public async Task<IActionResult> Manage()
    {
        var finePayments = await finePaymentService.GetFinePayments();
        return View(finePayments);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var model = await finePaymentService.GetFinePayment(id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateFinePaymentVM paymentToUpdate)
    {
        try
        {
            var response = await finePaymentService.UpdateFinePayment(paymentToUpdate);

            if (response.Successs)
                return RedirectToAction(nameof(Manage));
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await finePaymentService.DeleteFinePayment(id);

            if (response.Successs)
                return RedirectToAction(nameof(Manage));
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("Manage");
    }
}
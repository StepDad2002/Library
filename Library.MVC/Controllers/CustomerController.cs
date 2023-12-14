using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers;

public class CustomerController(ICustomerService customerService) : Controller
{
    // GET
    public async Task<IActionResult> Reservations(int customerId)
    {
        var customerReservations = await customerService.GetCustomerReservations(customerId);
        return View(customerReservations);
    }
    
    public async Task<IActionResult> Reviews(int customerId)
    {
        var customerReviews = await customerService.GetCustomerReviews(customerId);
        return View(customerReviews);
    }
    
    public async Task<IActionResult> Loans(int customerId)
    {
        var customerLoans = await customerService.GetCustomerLoans(customerId);
        return View(customerLoans);
    }
    
    [HttpGet]
    public async Task<IActionResult> Manage()
    {
        var customers = await customerService.GetCustomers();
        return View(customers);
    }

    public async Task<IActionResult> Search(UserSearchOptionsVM user)
    {
        List<CustomerListVM> customers = new();
        if (!string.IsNullOrWhiteSpace(user.Phone))
        {
            customers.Add(await customerService.GetCustomerByPhone(user.Phone));    
        }
        if (!string.IsNullOrWhiteSpace(user.Email))
        {
            customers.Add(await customerService.GetCustomerByEmail(user.Email));    
        }

        return View("Manage", customers.DistinctBy(x => x.Id));
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await customerService.DeleteCustomer(id);

            if (response.Successs)
                return RedirectToAction(nameof(Manage));
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction(nameof(Manage));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await customerService.GetCustomer(id);
        return View(customer);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateCustomerVM customerToUpdate)
    {
        try
        {
            var response = await customerService.UpdateCustomer(customerToUpdate);

            if (response.Successs)
                return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction("Index", "Home");
    }
}
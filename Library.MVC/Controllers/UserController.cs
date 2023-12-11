using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.Customer;
using Library.MVC.Models.Staff;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers;

public class UserController
    (ILoginService loginService, ICustomerService customerService, IStaffService staffService, ILocalStorageService localStorageService) : Controller
{
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {
            var isCustomerLoggedIn = await loginService.LogInCustomer(login);
            if (isCustomerLoggedIn)
            {
                int userId = localStorageService.GetStorageValue<int>("UserID");
                var customer = await customerService.GetCustomer(userId);
                HttpContext.Session.SetString("UserID", userId.ToString());
                HttpContext.Session.SetString("UserName", customer.FName + " " + customer.LName);
                HttpContext.Session.SetString("UserEmail", customer.Email);
                HttpContext.Session.SetString("IsCustomerLoggedIn", "true");
                
                return LocalRedirect("~/");
            }
            var isStaffLoggedIn = await loginService.LogInStaff(login);
            if (isStaffLoggedIn)
            {
                int userId = localStorageService.GetStorageValue<int>("UserID");
                var staff = await staffService.GetStaff(userId);
                HttpContext.Session.SetString("UserID", userId.ToString());
                HttpContext.Session.SetString("UserName", staff.FName + " " + staff.LName);
                HttpContext.Session.SetString("UserEmail", staff.Email);
                HttpContext.Session.SetString("IsStaffLoggedIn", "true");
                
                return LocalRedirect("~/");
            }
        }

        ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
        return View("Login", login);
    }
    

    public async Task<IActionResult> RegisterCustomer()
    {
        return View();
    }


    public async Task<IActionResult> RegisterStaff()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCustomer(CreateCustomerVM customer)
    {
        if (ModelState.IsValid)
        {
            var apiResponse = await customerService.CreateCustomer(customer);
            if (apiResponse.Data > 0)
                return LocalRedirect("~/");
        }

        ModelState.AddModelError("", "Registration Attempt Failed. Please try again.");
        return View("RegisterCustomer", customer);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterStaff(CreateStaffVM staff)
    {
        if (ModelState.IsValid)
        {
            var apiResponse = await staffService.CreateStaff(staff);
            if (apiResponse.Data > 0)
                return LocalRedirect("~/");
        }

        ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
        return View("RegisterStaff", staff);
    }

    public async Task<IActionResult> Logout()
    {
        await loginService.LogOut();
        HttpContext.Session.Remove("IsCustomerLoggedIn");
        HttpContext.Session.Remove("IsStaffLoggedIn");
        HttpContext.Session.Remove("UserName");
        HttpContext.Session.Remove("UserID");
        HttpContext.Session.Remove("UserEmail");
        return RedirectToAction("Index", "Home");
    }
}
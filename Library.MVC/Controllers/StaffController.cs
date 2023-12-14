using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Models.Staff;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers;

public class StaffController(IStaffService staffService) : Controller
{
    // GET
    public async Task<IActionResult> Search(UserSearchOptionsVM user)
    {
        List<StaffListVM> staffs = new();
        if (!string.IsNullOrWhiteSpace(user.Phone))
        {
            staffs.Add(await staffService.GetStaffByPhone(user.Phone));    
        }
        if (!string.IsNullOrWhiteSpace(user.Email))
        {
            staffs.Add(await staffService.GetStaffByEmail(user.Email));    
        }

        return View("Manage", staffs.DistinctBy(x => x.Id));
    }
    
    [HttpGet]
    public async Task<IActionResult> Manage()
    {
        var staffs = await staffService.GetStaffs();
        return View(staffs);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var customer = await staffService.GetStaff(id);
        return View(customer);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateStaffVM staffToUpdate)
    {
        try
        {
            var response = await staffService.UpdateStaff(staffToUpdate);

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
    
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await staffService.DeleteStaff(id);

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
}
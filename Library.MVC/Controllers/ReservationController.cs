using Library.MVC.Contracts;
using Library.MVC.Models.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers;

public class ReservationController(IReservationService reservationService) : Controller
{
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult>  Create(CreateReservationVM reservationVm)
    {
        try
        {
            var response = await reservationService.CreateReservation(reservationVm);
            if (response.Successs)
            {
                return RedirectToAction("Details", "Book", new {id = reservationVm.BookId});
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        
        return RedirectToAction("Details", "Book", new {id = reservationVm.BookId});
    }

    public async Task<IActionResult> Edit(int id)
    {
        var reservation = await reservationService.GetReservation(id);
        return View(reservation);
    }
    
    [HttpPost]
    public async Task<IActionResult>  Edit(UpdateReservationVM reservationToUpdate, int customerId)
    {
        try
        {
            var response = await reservationService.UpdateReservation(reservationToUpdate);
            if (response.Successs)
            {
                return RedirectToAction("Reservations", "Customer", new {customerId});
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        
        return RedirectToAction("Reservations", "Customer", new {customerId});
    }
    
    [HttpPost]
    public async Task<IActionResult>  EditFromManagement(UpdateReservationVM reservationToUpdate)
    {
        try
        {
            var response = await reservationService.UpdateReservation(reservationToUpdate);
            if (response.Successs)
            {
                return RedirectToAction(nameof(Manage));
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("Edit", reservationToUpdate);
    }
    
    [HttpGet]
    public async Task<IActionResult> Manage()
    {
        var reservations = await reservationService.GetReservations();
        return View(reservations);
    }

    public async Task<IActionResult> Delete(int id, int? userId)
    {
        try
        {
            var response = await reservationService.DeleteReservation(id);

            if (response.Successs)
                return RedirectToAction("Reservations", "Customer" ,new{ customerId = userId});
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return RedirectToAction("Reservations", "Customer" ,new{ customerId = userId});
    }
    
    public async Task<IActionResult> DeleteFromManagement(int id)
    {
        try
        {
            var response = await reservationService.DeleteReservation(id);

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

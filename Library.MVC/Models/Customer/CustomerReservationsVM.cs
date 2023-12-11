using System.ComponentModel.DataAnnotations;
using Library.MVC.Models.Reservation;

namespace Library.MVC.Models.Customer;

public class CustomerReservationsVM : IPersonVM
{
    public int Id { get; set; }


    public ICollection<ReservationListNoCustomerVM>? Reservations { get; set; }


    public string? FName { get; set; }


    public string? LName { get; set; }


    public string? Email { get; set; }


    public string? Phone { get; set; }
}
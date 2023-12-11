using Library.Domain.Enums;
using Library.MVC.CustomValidationAttrs;
using Library.MVC.Models.Book;
using Library.MVC.Models.Customer;

namespace Library.MVC.Models.Reservation;

public class ReservationVM : UpdateReservationVM
{
    
    public CustomerListVM Customer { get; set; }

    public BookNoReferencesVM Book { get; set; }

}
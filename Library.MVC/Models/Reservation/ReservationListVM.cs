using Library.MVC.Models.Book;
using Library.MVC.Models.Customer;

namespace Library.MVC.Models.Reservation;

public class ReservationListVM
{
    public int Id { get; set; }
    public CustomerListVM Customer { get; set; }

    public BookNoReferencesVM Book { get; set; }

    public int Amount { get; set; }
    
    public string Status { get; set; }
    
    public DateTime ReservationDate { get; set; }
    public DateTime DueDate { get; set; }
}
using Library.MVC.Models.Book;

namespace Library.MVC.Models.Reservation;

public class ReservationListNoCustomerVM
{
    public int Id { get; set; }

    public BookNoReferencesVM Book { get; set; }

    public int Amount { get; set; }
    
    public string Status { get; set; }
    
    public DateTime ReservationDate { get; set; }
    public DateTime DueDate { get; set; }
}
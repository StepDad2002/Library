namespace Library.MVC.Models;

public class ReservationSearchOptionsVM : ManagementBaseSearchOptionsVM
{
    public DateTime? ReservationDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string Status { get; set; }
}
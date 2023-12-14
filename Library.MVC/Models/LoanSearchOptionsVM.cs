namespace Library.MVC.Models;

public class LoanSearchOptionsVM : ManagementBaseSearchOptionsVM
{
    public DateTime? LoanDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
}
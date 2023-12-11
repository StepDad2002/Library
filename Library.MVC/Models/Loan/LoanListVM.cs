using Library.MVC.Models.Book;
using Library.MVC.Models.Customer;

namespace Library.MVC.Models.Loan;

public class LoanListVM : CreateLoanVM
{
    public int Id { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public BookNoReferencesVM Book { get; set; }

    public CustomerListVM Customer { get; set; }
    
}
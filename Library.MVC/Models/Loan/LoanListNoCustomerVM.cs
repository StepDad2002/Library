using Library.MVC.Models.Book;

namespace Library.MVC.Models.Loan;

public class LoanListNoCustomerVM : CreateLoanVM
{
    public int Id { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public BookNoReferencesVM Book { get; set; }
    
}
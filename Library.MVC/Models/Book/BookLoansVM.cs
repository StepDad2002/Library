using Library.MVC.Models.Loan;

namespace Library.MVC.Models.Book;

public class BookLoansVM
{
    public int Id { get; set; }
    
    public ICollection<LoanListVM>? Loans { get; set; }
}
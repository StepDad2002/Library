using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;
using Library.MVC.Models.Book;
using Library.MVC.Models.Customer;

namespace Library.MVC.Models.Loan;

public class LoanVM : UpdateLoanVM
{

    public BookNoReferencesVM Book { get; set; }

    public CustomerListVM Customer { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.Loan;

public class CreateLoanVM
{
    [DateCompare(false, nameof(ReturnedDate))]
    [DateNotInFuture, DateRange( "01/01/1753", "12/31/9999")]
    public DateTime LoanDate { get => DateTime.Now; }
    
    public int BookId { get; set; }
    
    [Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int CustomerId { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [DateNotInFuture, DateRange( "01/01/1753", "12/31/9999")]
    public DateTime ReturnedDate { get; set; }

    [Range(1, int.MaxValue, MinimumIsExclusive = false)]
    public decimal FineAmount { get; set; }
}
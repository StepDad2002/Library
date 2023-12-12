using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.Loan;

public class CreateLoanVM
{
    [DateCompare(false, nameof(ReturnedDate))]
    [DateNotInFuture, DateRange( "01/01/1753", "12/31/9999")]
    public DateTime LoanDate { get => DateTime.Now; }
    
    [Required]
    [Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int BookId { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int CustomerId { get; set; }
    
    [DateNotInFuture, DateRange( "01/01/1753", "12/31/9999")]
    public DateTime DueDate { get; set; }
    
    [Required, DateNotInFuture, DateRange( "01/01/1753", "12/31/9999")]
    public DateTime ReturnedDate { get; set; }

    [Required, Range(1, int.MaxValue, MinimumIsExclusive = false)]
    public decimal FineAmount { get; set; }
}
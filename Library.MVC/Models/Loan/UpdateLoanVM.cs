using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.Loan;

public class UpdateLoanVM
{
    public int Id { get; set; }
    [DateCompare(false,nameof(ReturnedDate))]
    [DateRange("1/1/1793", "12/31/9999"), DateNotInFuture]
    public DateTime DueDate { get; set; }
    
    [Required, DateRange("1/1/1793", "12/31/9999"), DateNotInFuture]
    public DateTime ReturnedDate { get; set; }

    [Required, Range(1, int.MaxValue, MinimumIsExclusive = false)]
    public decimal FineAmount { get; set; }
}
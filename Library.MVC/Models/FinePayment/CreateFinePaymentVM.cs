using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.FinePayment;

public class CreateFinePaymentVM 
{
    [Range(0, Int32.MaxValue, MaximumIsExclusive = true)]
    public int CustomerId { get; set; }

    [Range(0, Int32.MaxValue, MaximumIsExclusive = true)]
    public decimal Amount { get; set; }
    [DateNotInFuture, DateRange( "1/1/1753", "31/12/9999")]
    public DateTime PaymentDate { get => DateTime.Now; }
}
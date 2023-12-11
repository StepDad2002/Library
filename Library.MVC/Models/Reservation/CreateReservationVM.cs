using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.Reservation;

public class CreateReservationVM 
{
    [Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int CustomerId { get; set; }
    [Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int BookId { get; set; }
    [Range(0, 5000, MinimumIsExclusive = true)]
    public int Amount { get; set; }

    [DateCompare(false, nameof(DueDate))]
    public DateTime ReservationDate
    {
        get => DateTime.Now;
    }

    [DateRange( "1/1/0001", "12/31/9999", ShouldNotBeInFuture = true, ErrorMessage = "Invalid Date")]
    public DateTime DueDate { get; set; }
}
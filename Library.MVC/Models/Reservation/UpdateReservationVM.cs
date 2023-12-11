using System.ComponentModel.DataAnnotations;
using Library.Domain.Enums;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.Reservation;

public class UpdateReservationVM
{
    public int Id { get; set; }
    [Required,IsEnumName(typeof(Status))]
    public string Status { get; set; }
    [Range(0, 5000, MinimumIsExclusive = true)]
    public int Amount { get; set; }
}
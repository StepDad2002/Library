using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Reservation;

public class UpdateReservationDto : BaseDto
{
    public string Status { get; set; }

    public int Amount { get; set; }
}


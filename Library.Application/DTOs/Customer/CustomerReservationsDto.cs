using Library.Application.DTOs.Common;
using Library.Application.DTOs.Reservation;

namespace Library.Application.DTOs.Customer;

public class CustomerReservationsDto : BaseDto, IPersonDto
{
    public ICollection<ReservationListNoCustomerDto>? Reservations { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}
using Library.Application.DTOs.Reservation;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Queries;

public class GetReservationByCustomerPhoneListRequest : IRequest<List<ReservationListDto>>
{
    public string Phone { get; set; }
}
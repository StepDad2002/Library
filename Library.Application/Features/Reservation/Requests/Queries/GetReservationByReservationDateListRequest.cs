using Library.Application.DTOs.Reservation;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Queries;

public class GetReservationByReservationDateListRequest : IRequest<List<ReservationListDto>>
{
    public DateTime ReservationDate { get; set; }
}
using Library.Application.DTOs.Reservation;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Queries;

public class GetReservationByDueDateListRequest : IRequest<List<ReservationListDto>>
{
    public DateTime DueDate { get; set; }
}
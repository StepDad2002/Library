using Library.Application.DTOs.Reservation;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Queries;

public class GetReservationByBookTitleListRequest : IRequest<List<ReservationListDto>>
{
    public string BookTitle { get; set; }
}

public class GetReservationByStatusListRequest : IRequest<List<ReservationListDto>>
{
    public string Status { get; set; }
}
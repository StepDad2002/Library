using Library.Application.DTOs.Reservation;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Queries;

public class GetReservationListRequest : IRequest<List<ReservationListDto>>
{

}
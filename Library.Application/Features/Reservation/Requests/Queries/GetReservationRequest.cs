using Library.Application.DTOs.Reservation;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Queries;

public class GetReservationRequest : IRequest<ReservationDto>
{
    public int Id { get; set; }
}
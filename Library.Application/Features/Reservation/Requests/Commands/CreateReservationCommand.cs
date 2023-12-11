using Library.Application.DTOs.Reservation;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Commands;

public class CreateReservationCommand : IRequest<BaseCommandResponse>
{
    public CreateReservationDto Reservation { get; set; }
}
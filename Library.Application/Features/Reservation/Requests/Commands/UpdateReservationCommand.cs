using Library.Application.DTOs.Reservation;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Reservation.Requests.Commands;

public class UpdateReservationCommand : IRequest<UpdateCommandResponse>
{
    public UpdateReservationDto Reservation { get; set; }
}
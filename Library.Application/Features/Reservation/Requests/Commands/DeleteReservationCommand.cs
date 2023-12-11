using MediatR;

namespace Library.Application.Features.Reservation.Requests.Commands;

public class DeleteReservationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
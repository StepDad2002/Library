using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.Reservation.Requests.Commands;
using Library.Domain.Enums;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Commands;

public class DeleteReservationCommandHandler
    (IUnitOfWork unitOfWork) : IRequestHandler<DeleteReservationCommand, Unit>
{
    public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await unitOfWork.ReservationRepository.GetReservationWithDetailsAsync(request.Id);

        if (reservation == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Reservation), request.Id);


        await unitOfWork.BookRepository.IncreaseCopiesAvailable(reservation.BookId, reservation.Amount);
        await unitOfWork.ReservationRepository.DeleteAsync(reservation);
        await unitOfWork.SaveAsync();


        return Unit.Value;
    }
}
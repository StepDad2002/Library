using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Reservation.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Commands;

public class UpdateReservationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<UpdateReservationCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateReservationDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Reservation);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Reservation;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var reservation = await unitOfWork.ReservationRepository.GetAsync(request.Reservation.Id);
            
            if(reservation is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Reservation), request.Reservation.Id);

            var bookToUpdate = await unitOfWork.BookRepository.GetAsync(reservation.BookId);
            
            if(bookToUpdate is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), reservation.BookId);
            
            if (reservation.Amount > request.Reservation.Amount)
                bookToUpdate.CopiesAvailable += reservation.Amount - request.Reservation.Amount;
            if (reservation.Amount < request.Reservation.Amount)
                bookToUpdate.CopiesAvailable -= request.Reservation.Amount - reservation.Amount;
            
            mapper.Map(request.Reservation, reservation);
            await unitOfWork.ReservationRepository.UpdateAsync(reservation);
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = reservation.Id;
        }

        return response;
    }
}
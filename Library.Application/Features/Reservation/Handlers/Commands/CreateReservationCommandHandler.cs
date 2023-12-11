using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation.Validators;
using Library.Application.Features.Reservation.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Commands;

public class CreateReservationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<CreateReservationCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new CreateReservationDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Reservation);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var reservation = mapper.Map<Domain.Entities.Schemas.Management.Reservation>(request.Reservation);
            await unitOfWork.BookRepository.DecreaseCopiesAvailable(request.Reservation.BookId, request.Reservation.Amount);
            
            await unitOfWork.ReservationRepository.AddAsync(reservation);
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = reservation.Id;
        }

        return commandResponse;
    }
}
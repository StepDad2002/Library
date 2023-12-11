using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Loan.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Loan.Handlers.Commands;

public class CreateLoanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateLoanCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new CreateLoanValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Loan);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var loanDto = request.Loan;
            var reservation =
                await unitOfWork.ReservationRepository.GetReservationWithDetailsAsync(loanDto.BookId, loanDto.CustomerId);

            if (reservation is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Reservation), -1);
            
            var loan = mapper.Map<Domain.Entities.Schemas.Management.Loan>(loanDto);
            loan.DueDate = reservation.DueDate;
            await unitOfWork.LoanRepository.AddAsync(loan);
            
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = loan.Id;
        }

        return commandResponse;
    }
}
using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Loan.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Loan.Handlers.Commands;

public class UpdateLoanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<UpdateLoanCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateLoanDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Loan);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Loan;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var loan = await unitOfWork.LoanRepository.GetAsync(request.Loan.Id);

            if (loan is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Loan), request.Loan.Id);
            
            mapper.Map(request.Loan, loan);
            await unitOfWork.LoanRepository.UpdateAsync(loan);
            
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = loan.Id;
        }

        return response;
    }
}
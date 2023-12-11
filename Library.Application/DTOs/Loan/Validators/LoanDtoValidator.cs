using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Loan.Validators;

public class LoanDtoValidator : AbstractValidator<ILoanDto>
{

    public LoanDtoValidator(IUnitOfWork unitOfWork)
    {

        RuleFor(x => x.CustomerId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                return await unitOfWork.CustomerRepository.ExistsAsync(id);
            })
            .WithMessage("{PropertyName} is not exist");

        RuleFor(x => x.BookId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                return await unitOfWork.BookRepository.ExistsAsync(id);
            })
            .WithMessage("{PropertyName} is not exist");

        RuleFor(x => x.FineAmount)
            .GreaterThan(0)
            .NotEmpty().WithMessage("{PropertyName} is required");
        
    }
}
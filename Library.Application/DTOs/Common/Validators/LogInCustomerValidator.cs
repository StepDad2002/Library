using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Common.Validators;

public class LogInCustomerValidator : AbstractValidator<LogInDto>
{
    public LogInCustomerValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .MustAsync(async (email, token) =>
            {
                return await unitOfWork.CustomerRepository.ExistEmailAsync(email);
            }).WithMessage("{PropertyName} does not exist");
        
        RuleFor(x => x.Password)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .MustAsync(async (password, token) =>
            {
                return await unitOfWork.CustomerRepository.ExistPasswordAsync(password);
            }).WithMessage("{PropertyName} does not exist");
    }
}
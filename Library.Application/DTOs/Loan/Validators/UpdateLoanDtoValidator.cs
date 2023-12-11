using FluentValidation;

namespace Library.Application.DTOs.Loan.Validators;

public class UpdateLoanDtoValidator : AbstractValidator<UpdateLoanDto>
{
    public UpdateLoanDtoValidator()
    {
        RuleFor(x => x.FineAmount)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(x => x.ReturnedDate)
            .GreaterThan(p => p.DueDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
        
        RuleFor(x => x.DueDate)
            .LessThan(p => p.ReturnedDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
        
        
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
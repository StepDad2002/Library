using FluentValidation;

namespace Library.Application.DTOs.FinePayment.Validators;

public class UpdateFinePaymentValidator : AbstractValidator<UpdateFinePaymentDto>
{

    public UpdateFinePaymentValidator()
    {
        
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .NotEmpty().WithMessage("{PropertyName} must be greater than 0");
        
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
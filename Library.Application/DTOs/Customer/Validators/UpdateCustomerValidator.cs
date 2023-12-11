using FluentValidation;
using Library.Application.DTOs.Common.Validators;

namespace Library.Application.DTOs.Customer.Validators;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDto>
{
    public UpdateCustomerValidator()
    {
        Include(new PersonValidator());
        
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
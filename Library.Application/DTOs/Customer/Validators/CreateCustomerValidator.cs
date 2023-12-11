using FluentValidation;
using Library.Application.DTOs.Common.Validators;

namespace Library.Application.DTOs.Customer.Validators;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerValidator()
    {
        Include(new PersonValidator());
    }
}
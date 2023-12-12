using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Common.Validators;

namespace Library.Application.DTOs.Customer.Validators;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerValidator(IUnitOfWork unitOfWork)
    {
        Include(new PersonValidator());
        
        RuleFor(x => x.Email)
            .MustAsync(async (email, token) =>
            {
                return !await unitOfWork.StaffRepository.ExistsEmailAsync(email);
            }).WithMessage("This {PropertyName} id already exists");
        
        RuleFor(x => x.Phone)
            .MustAsync(async (phone, token) =>
            {
                return !await unitOfWork.StaffRepository.ExistsPhoneAsync(phone);
            }).WithMessage("This {PropertyName} id already exists");
    }
}
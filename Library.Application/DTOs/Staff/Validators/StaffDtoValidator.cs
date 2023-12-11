using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Common.Validators;
using Library.Domain.Enums;

namespace Library.Application.DTOs.Validators;

public class StaffDtoValidator : AbstractValidator<CreateStaffDto>
{
    public StaffDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new PersonValidator());

        RuleFor(x => x.Position)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .IsEnumName(typeof(Position)).WithMessage("Accepted values for {PropertyName}: " 
                                                      + string.Join("|", Enum.GetNames<Position>()))
            .NotNull();

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

        RuleFor(x => x.Salary)
            .GreaterThanOrEqualTo(250).WithMessage("{PropertyName} must be greater than {ComparisonValue}");
    }
}
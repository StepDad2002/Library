using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Common.Validators;
using Library.Domain.Enums;

namespace Library.Application.DTOs.Validators;

public class UpdateStaffDtoValidator : AbstractValidator<UpdateStaffDto>
{
    public UpdateStaffDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new PersonValidator());

        RuleFor(x => x.Position)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .IsEnumName(typeof(Position)).WithMessage("Accepted values for {PropertyName}: "
                                                      + string.Join("|", Enum.GetNames<Position>()))
            .NotNull();

        RuleFor(x => x.Email)
            .MustAsync(async (dto, email, token) =>
            {
                var isEmailExistsInSystem = await unitOfWork.StaffRepository.ExistsEmailAsync(email);
                var existingStaff = await unitOfWork.StaffRepository.GetAsyncNoTracking(dto.Id);
                if (existingStaff == null)
                    return true;
                if (isEmailExistsInSystem && existingStaff.Email != email)
                    return false;
                return true;
            }).WithMessage("This {PropertyName} id already exists");

        RuleFor(x => x.Phone)
            .MustAsync(async (dto, phone, token) =>
            {
                var isPhoneExistsInSystem = await unitOfWork.StaffRepository.ExistsPhoneAsync(phone);
                var existingStaff = await unitOfWork.StaffRepository.GetAsyncNoTracking(dto.Id);
                if (existingStaff == null)
                    return true;
                if (isPhoneExistsInSystem && existingStaff.Phone != phone)
                    return false;
                return true;
            }).WithMessage("This {PropertyName} id already exists");

        RuleFor(x => x.Salary)
            .GreaterThan(250).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
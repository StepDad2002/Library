using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Domain.Enums;

namespace Library.Application.DTOs.Reservation.Validators;

public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
{

    public UpdateReservationDtoValidator(IUnitOfWork unitOfWork)
    {

        RuleFor(x => x.Status)
            .IsEnumName(typeof(Status))
            .WithMessage("Allowed values for {PropertyName}: " + string.Join("|", Enum.GetNames<Status>()));

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} should be greater than 1")
            .MustAsync(async (dto, amount, token) =>
            {
                var reservation = await unitOfWork.ReservationRepository.GetAsyncNoTracking(dto.Id);
                var bookCopies = (await unitOfWork.BookRepository.GetAsyncNoTracking(reservation.BookId))
                    .CopiesAvailable;
                return amount <= bookCopies;
            }).WithMessage("{PropertyName} should be lower or equal than total book copies that are available");
        
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
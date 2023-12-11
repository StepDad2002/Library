using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Reservation.Validators;

public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
{

    public CreateReservationDtoValidator(IUnitOfWork unitOfWork)
    {

        RuleFor(x => x.BookId)
            .MustAsync(async (id, token) =>
            {
                return await unitOfWork.BookRepository.ExistsAsync(id);
            }).WithMessage("{PropertyName} is not exist")
            .GreaterThan(0);

        RuleFor(x => x.CustomerId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                return await unitOfWork.CustomerRepository.ExistsAsync(id);
            }).WithMessage("{PropertyName} is not exist");;

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater then 0")
            .MustAsync(async (dto, amount, token) =>
            {
                var book = await unitOfWork.BookRepository.GetAsyncNoTracking(dto.BookId);
                if (book != null)
                {
                    return amount <= book.CopiesAvailable;
                }
                return false; //book was not found secondary
               // return true;
            }).WithMessage("{PropertyName} must be lower that actual copies available for book");

        RuleFor(x => x.DueDate)
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .NotNull().WithMessage("{PropertyName} is required")
            .GreaterThanOrEqualTo(x => x.ReservationDate)
            .WithMessage("{PropertyName} must be greater or equal to {ComparisonValue}");

    }
}
using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Loan.Validators;

public class CreateLoanValidator : AbstractValidator<CreateLoanDto>
{
    public CreateLoanValidator(IUnitOfWork unitOfWork)
    {
        Include(new LoanDtoValidator(unitOfWork));


        RuleFor(x => x.ReturnedDate)
            .MustAsync(async (dto, date, arg3) =>
            {
                var reserv = await unitOfWork.ReservationRepository
                    .GetReservationWithDetailsAsync(dto.BookId, dto.CustomerId);
                if (reserv != null)
                {
                    return reserv.DueDate <= date;
                }

                return false;
            } )
            .WithMessage("Reservation was not found or {PropertyName} is greater then due date");

      

    }
}
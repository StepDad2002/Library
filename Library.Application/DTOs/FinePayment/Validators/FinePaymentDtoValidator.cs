using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.FinePayment.Validators;

public class FinePaymentDtoValidator : AbstractValidator<IFinePaymentDto>
{

    public FinePaymentDtoValidator(IUnitOfWork unitOfWork)
    {

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0")
            .MustAsync(async (id, token) =>
            {
                return await unitOfWork.CustomerRepository.ExistsAsync(id);
            }).WithMessage("{PropertyName} does not exists");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .NotEmpty().WithMessage("{PropertyName} is required");;
    }
}
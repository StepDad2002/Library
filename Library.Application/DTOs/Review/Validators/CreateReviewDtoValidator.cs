using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Review.Validators;

public class CreateReviewDtoValidator : AbstractValidator<CreateReviewDto>
{
    public CreateReviewDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new ReviewDtoValidator());

        RuleFor(p => p.BookId)
            .GreaterThan(0)
            .MustAsync(async (id, token) => { return await unitOfWork.BookRepository.ExistsAsync(id); })
            .WithMessage("{PropertyName} does not exists");

        RuleFor(p => p.CustomerId)
            .GreaterThan(0)
            .MustAsync(async (dto, id, token) =>
            {
                return await unitOfWork.CustomerRepository.ExistsAsync(id) &&
                       await unitOfWork.ReviewRepository.HasCustomerAlreadyReviewed(dto.CustomerId, id);
            })
            .WithMessage("{PropertyName} does not exists");

        RuleFor(p => p.CustomerId)
            .GreaterThan(0)
            .MustAsync(async (dto, id, token) =>
            {
                var result = await unitOfWork.ReviewRepository.HasCustomerAlreadyReviewed(dto.CustomerId, dto.BookId);
                return result;
            })
            .WithMessage("Can not leave Review twice");
    }
}
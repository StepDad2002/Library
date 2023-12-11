using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Book.Validators;

public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
{

    public UpdateBookDtoValidator(IUnitOfWork unitOfWork)
    {

        Include(new BookDtoValidator());

        RuleFor(x => x.Description)
            .MaximumLength(350).WithMessage("{PropertyName} should be maximum 350 characters");

        RuleFor(x => x.Isbn)
            .NotNull()
            .NotEmpty()
            .MustAsync(async (dto, isbn, d) =>
            {
                var isIsbnExistsInSystem = await unitOfWork.BookRepository.ExistsAsync(isbn);
                var existingBook = await unitOfWork.BookRepository.GetAsyncNoTracking(dto.Id);
                if (existingBook == null)
                    return true;
                if (isIsbnExistsInSystem && existingBook.Isbn != isbn)
                    return false;
                return true;
            }).WithMessage("{PropertyName} already exists")
            .MinimumLength(7)
            .WithMessage("{PropertyName} should be at least of 7 characters");
        

        RuleFor(x => x.CopiesAvailable)
            .GreaterThan(0).WithMessage("{PropertyName} should be greater then 0")
            .NotNull();

        RuleFor(x => x.AvgRating)
            .InclusiveBetween(0, 10).WithMessage("{PropertyName} should be in range from 0 inclusive to 10 inclusive");

        RuleFor(x => x.PublicationDate)
            .NotNull().WithMessage("{PropertyName} is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must be less then {ComparisonValue}");

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
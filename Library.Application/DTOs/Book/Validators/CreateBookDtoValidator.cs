using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Author;
using Library.Application.DTOs.Publisher.Validators;

namespace Library.Application.DTOs.Book.Validators;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new BookDtoValidator());

        RuleFor(x => x.Isbn)
            .NotNull()
            .NotEmpty()
            .MustAsync(async (isbn, d) => { return !await unitOfWork.BookRepository.ExistsAsync(isbn); })
            .WithMessage("{PropertyName} already exists")
            .MinimumLength(7)
            .WithMessage("{PropertyName} should be at least of 7 characters");

        RuleFor(x => x.ShelfId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                if (id.HasValue)
                    return await unitOfWork.ShelfRepository.ExistsAsync(id.Value);
                return true;
            })
            .WithMessage("{PropertyName} is not exists");

        RuleFor(x => x.Publisher)
            .NotNull().WithMessage("{PropertyName} is required")
            .ChildRules(child => { child.Include(new PublisherDtoValidator(unitOfWork)); });

        RuleFor(x => x.Authors)
            .ForEach(child => { child.SetValidator(new AuthorDtoValidator()); })
            .Custom((coll, context) =>
            {
                if (coll.Count() < 1)
                    context.AddFailure("Book must have at least one author");
            });

        RuleFor(x => x.CopiesAvailable)
            .NotEmpty()
            .GreaterThan(0).WithMessage("{PropertyName} must be greater then 0");
        ;

        RuleFor(x => x.PublicationDate)
            .LessThan(DateTime.UtcNow)
            .NotEmpty().WithMessage("{PropertyName} should be less than {ComparisonValue}");
        ;
    }
}
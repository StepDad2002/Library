using FluentValidation;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Book.Validators;

public class BookDtoValidator : AbstractValidator<IBookDto>
{

    public BookDtoValidator()
    {
        RuleFor(x => x.Categorie)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(x => x.Language)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required");

       


        RuleFor(x => x.Genres)
            .NotNull().WithMessage("{PropertyName} is required")
            .Custom((genres, context) =>
            {
                if (genres.Length < 1)
                    context.AddFailure("Book must contain at least one genre");
                if(genres.Any(x => string.IsNullOrWhiteSpace(x)))
                    context.AddFailure("Genre can not be empty");
                   
            });

        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull().WithMessage("{PropertyName} is required")
            .MaximumLength(120).WithMessage("{PropertyName} should be maximum 120 characters");;
    }
}
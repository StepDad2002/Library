using FluentValidation;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Author;

public class AuthorDtoValidator : AbstractValidator<IAuthorDto>
{
    public AuthorDtoValidator()
    {
        RuleFor(x => x.FName)
            .MaximumLength(25)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");
        
        RuleFor(x => x.MName)
            .MaximumLength(25)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");


        RuleFor(x => x.LName)
            .MaximumLength(25)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");


        
    }
}
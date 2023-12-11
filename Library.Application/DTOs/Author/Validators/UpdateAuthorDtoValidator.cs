using FluentValidation;

namespace Library.Application.DTOs.Author;

public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorDto>
{
    public UpdateAuthorDtoValidator()
    {
        Include(new AuthorDtoValidator());

        RuleFor(x => x.Biography)
            .MaximumLength(500).WithMessage("{PropertyName} must be less then 500 characters");

        RuleFor(x => x.Nationality)
            .MaximumLength(50).WithMessage("{PropertyName} must be greater then 50 characters");;

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        
        RuleFor(x => x.BirthDay)
            .LessThan(DateTime.UtcNow)
            .WithMessage("{PropertyName} must be less than {ComparisonValue}");
    }
}
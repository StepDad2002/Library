using FluentValidation;

namespace Library.Application.DTOs.Shelf.Validators;

public class ShelfDtoValidator : AbstractValidator<IShelfDto>
{
    public ShelfDtoValidator()
    {
        RuleFor(x => x.Description)
            .MaximumLength(150).WithMessage("{PropertyName} should be less than 150 characters");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MaximumLength(60).WithMessage("{PropertyName} should be less than 60 characters");
    }
}
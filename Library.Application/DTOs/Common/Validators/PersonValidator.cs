using FluentValidation;

namespace Library.Application.DTOs.Common.Validators;

public class PersonValidator : AbstractValidator<IPersonDto>
{
    public PersonValidator()
    {
        RuleFor(x => x.LName)
            .MaximumLength(25)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");
        
        RuleFor(x => x.FName)
            .MaximumLength(25)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("{PropertyName} should be in a correct format");;

        
        RuleFor(x => x.Phone)
            .NotNull().WithMessage("{PropertyName} is required")
            .Matches(@"^\d{3}-\d{3}-\d{2}-\d{2}$").WithMessage("Required format fro {PropertyName}:" +
                                                               " xxx-xxx-xx-xx");
    }
}
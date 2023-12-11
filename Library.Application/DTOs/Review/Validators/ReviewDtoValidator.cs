using FluentValidation;

namespace Library.Application.DTOs.Review.Validators;

public class ReviewDtoValidator : AbstractValidator<IReviewDto>
{
    public ReviewDtoValidator() 
    {
        RuleFor(x => x.Comment)
            .NotEmpty()
            .NotNull().WithMessage("{PropertyName} is required")
            .MaximumLength(500).WithMessage("{PropertyName} should be less than 500 charaters");;
        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 10);
    }
}
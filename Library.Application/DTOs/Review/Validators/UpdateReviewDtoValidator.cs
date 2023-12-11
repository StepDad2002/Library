using FluentValidation;

namespace Library.Application.DTOs.Review.Validators;

public class UpdateReviewDtoValidator : AbstractValidator<UpdateReviewDto>
{
    public UpdateReviewDtoValidator()
    {
        Include(new ReviewDtoValidator());
        
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
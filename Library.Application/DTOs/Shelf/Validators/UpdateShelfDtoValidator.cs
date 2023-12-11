using FluentValidation;

namespace Library.Application.DTOs.Shelf.Validators;

public class UpdateShelfDtoValidator : AbstractValidator<UpdateShelfDto>
{
    public UpdateShelfDtoValidator()
    {
        Include(new ShelfDtoValidator());
    
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
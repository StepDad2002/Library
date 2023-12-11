using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Publisher.Validators;

public class UpdatePublisherDtoValidator : AbstractValidator<UpdatePublisherDto>
{
    public UpdatePublisherDtoValidator(IUnitOfWork unitOfWork)
    {
        Include(new PublisherDtoValidator(unitOfWork));

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
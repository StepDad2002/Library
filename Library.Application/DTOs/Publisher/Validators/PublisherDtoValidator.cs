using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Publisher.Validators;

public class PublisherDtoValidator : AbstractValidator<IPublisherDto>
{

    public PublisherDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(75).WithMessage("{PropertyName} must be less than 75 characters");

        RuleFor(x => x.Phone)
            .Matches(@"^\d{3}-\d{3}-\d{2}-\d{2}$").WithMessage("{PropertyName} is not matched")
            .MinimumLength(13)
            .MustAsync(async (dto,phone, token) =>
            {
                var publisher = await unitOfWork.PublisherRepository.GetByPhoneAsyncNoTracking(phone);
                if (publisher != null)
                {
                    if (publisher.Name.Equals(dto.Name))
                        return true;
                }
                return !await unitOfWork.PublisherRepository.ExistsPhoneAsync(phone);
            }).WithMessage("This {PropertyName} id already exists");
        RuleFor(x => x.WebSite)
            .Matches(@"^(http|https)://[a-zA-Z0-9-\.]+\.[a-zA-Z]{2,4}(/\S*)?$")
            .WithMessage("{PropertyName} is not matched")
            .MustAsync(async (dto,website, token) =>
            {
                var publisher = await unitOfWork.PublisherRepository.GetByWebSiteAsyncNoTracking(website);
                if (publisher != null)
                {
                    if (publisher.WebSite != null && publisher.WebSite.Equals(dto.WebSite))
                        return true;
                }
                return !await unitOfWork.PublisherRepository.ExistsWebsiteAsync(website);
            }).WithMessage("This {PropertyName} id already exists");
        


    }
}
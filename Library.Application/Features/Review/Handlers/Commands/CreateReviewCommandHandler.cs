using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Review.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Review.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Review.Handlers.Commands;

public class CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateReviewCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new CreateReviewDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Review);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var review = mapper.Map<Domain.Entities.Schemas.Management.Review>(request.Review);
            await unitOfWork.ReviewRepository.AddAsync(review);
            var ratingCountTuple = await unitOfWork.ReviewRepository.GetAvgRatingForBook(review.BookId);
            var bookToUpdate = await unitOfWork.BookRepository.GetAsync(review.BookId);

            if (bookToUpdate is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), request.Review.BookId);

            double? avgRating = ratingCountTuple.Count > 0 ? (ratingCountTuple.RatingSum.Value + review.Rating) / (ratingCountTuple.Count + 1) : (double)review.Rating;



            bookToUpdate.AvgRating = avgRating;
            
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = review.Id;
        }

        return commandResponse;
    }
}
using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Review.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Review.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Review.Handlers.Commands;

public class UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<UpdateReviewCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateReviewDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Review);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Review;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var review = await unitOfWork.ReviewRepository.GetAsync(request.Review.Id);

            if (review is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Review), request.Review.Id);

            if (review.Rating != request.Review.Rating)
            {
                var ratingCountTuple = await unitOfWork.ReviewRepository.GetAvgRatingForBook(review.BookId);
                var bookToUpdate = await unitOfWork.BookRepository.GetAsync(review.BookId);

                if (bookToUpdate is null)
                    throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), review.BookId);

                if (review.Rating.HasValue && request.Review.Rating.HasValue)
                {
                    bookToUpdate.AvgRating = ratingCountTuple.Count > 0
                        ? (ratingCountTuple.RatingSum - review.Rating.Value + request.Review.Rating.Value) /
                          ratingCountTuple.Count
                        : review.Rating;
                }
                else if (!review.Rating.HasValue && request.Review.Rating.HasValue)
                {
                    bookToUpdate.AvgRating = ratingCountTuple.Count > 0
                        ? (ratingCountTuple.RatingSum + request.Review.Rating.Value) /
                          ratingCountTuple.Count
                        : review.Rating;
                }
            }

            mapper.Map(request.Review, review);
            await unitOfWork.ReviewRepository.UpdateAsync(review);
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = review.Id;
        }

        return response;
    }
}
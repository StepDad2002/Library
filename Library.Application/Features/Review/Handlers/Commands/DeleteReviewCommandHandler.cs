using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.Review.Requests.Commands;
using MediatR;

namespace Library.Application.Features.Review.Handlers.Commands;

public class DeleteReviewCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<DeleteReviewCommand, Unit>
{
    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetAsync(request.Id);
        
        if (review == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Review), request.Id);
        
        var ratingCountTuple = await unitOfWork.ReviewRepository.GetAvgRatingForBook(review.BookId);
        var bookToUpdate = await unitOfWork.BookRepository.GetAsync(review.BookId);
            
        if (bookToUpdate is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), review.BookId);

        bookToUpdate.AvgRating = ratingCountTuple.Count == 1
            ? 0 : (ratingCountTuple.RatingSum - review.Rating) / (ratingCountTuple.Count - 1);

        await unitOfWork.ReviewRepository.DeleteAsync(review);
        await unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
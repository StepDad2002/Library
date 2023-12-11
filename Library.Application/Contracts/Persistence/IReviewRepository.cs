using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface IReviewRepository : IGenericRepository<Review>
{
    Task<Review?> GetReviewWithDetailsAsync(int id);

    Task<bool> HasCustomerAlreadyReviewed(int customerId, int bookId);
    Task<IReadOnlyList<Review>?> GetReviewsWithDetailsAsync();
    Task<(double? RatingSum, int Count)> GetAvgRatingForBook(int reviewBookId);
}
using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface IReviewRepository : IGenericRepository<Review>
{
    Task<Review?> GetReviewWithDetailsAsync(int id);

    Task<bool> HasCustomerAlreadyReviewed(int customerId, int bookId);
    Task<IReadOnlyList<Review>?> GetReviewsWithDetailsAsync();
    Task<IReadOnlyList<Review>?> GetReviewsByDateAsync(DateTime reviewDate);
    Task<IReadOnlyList<Review>?> GetReviewsByBookTitleAsync(string title);
    Task<IReadOnlyList<Review>?> GetReviewsByCustomerPhoneAsync(string phone);
    Task<IReadOnlyList<Review>?> GetReviewsByRatingAsync(int minRating, int? maxRating);
    Task<(double? RatingSum, int Count)> GetAvgRatingForBook(int reviewBookId);
}
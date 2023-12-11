using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class ReviewRepository(LibraryDbContext _dbContext) : GenericRepository<Review>(_dbContext), IReviewRepository
{
    public async Task<Review?> GetReviewWithDetailsAsync(int id)
    {
        return await _dbContext.Reviews
            .Where(x => x.Id == id)
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> HasCustomerAlreadyReviewed(int customerId, int bookId)
    {
        var review = await _dbContext.Reviews
            .AsNoTracking()
            .Where(x => x.CustomerId == customerId && x.BookId == bookId)
            .FirstOrDefaultAsync();

        return review is null;
    }

    public async Task<IReadOnlyList<Review>?> GetReviewsWithDetailsAsync()
    {
        return await _dbContext.Reviews
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .ToListAsync();
    }

    public async Task<(double? RatingSum, int Count)> GetAvgRatingForBook(int reviewBookId)
    {
        var reviews = _dbContext.Reviews
            .Where(x => x.BookId == reviewBookId);

        var ratingSum = await reviews.SumAsync(x => x.Rating);
        var count = await reviews.CountAsync();


        return (ratingSum, count);
    }
}
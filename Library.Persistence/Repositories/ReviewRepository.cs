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

    public async Task<IReadOnlyList<Review>?> GetReviewsByDateAsync(DateTime reviewDate)
    {
        return await _dbContext.Reviews
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.ReviewDate.Year == reviewDate.Year &&
                        x.ReviewDate.Month == reviewDate.Month &&
                        x.ReviewDate.Day == reviewDate.Day)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Review>?> GetReviewsByBookTitleAsync(string title)
    {
        return await _dbContext.Reviews
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Book.Title == title)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Review>?> GetReviewsByCustomerPhoneAsync(string phone)
    {
        return await _dbContext.Reviews
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Customer.Phone == phone)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Review>?> GetReviewsByRatingAsync(int minRating, int? maxRating)
    {
        return await _dbContext.Reviews
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Rating >= minRating && x.Rating <= maxRating)
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
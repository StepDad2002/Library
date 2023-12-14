using Library.MVC.Models.Review;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IReviewService
{
    Task<List<ReviewVM>> GetReviews();
    Task<List<ReviewVM>> GetReviewsByDate(DateTime date);
    Task<List<ReviewVM>> GetReviewsByRating(int minRating, int? maxRating);
    Task<List<ReviewVM>> GetReviewsByBookTitle(string title);
    Task<List<ReviewVM>> GetReviewsByCustomerPhone(string phone);
    Task<ReviewVM> GetReview(int id);
    Task<Response<int>> UpdateReview(UpdateReviewVM review);
    Task<Response<int>> CreateReview(CreateReviewVM review);
    Task<Response<int>> DeleteReview(int id);
}
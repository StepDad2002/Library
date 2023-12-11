using Library.MVC.Models.Review;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IReviewService
{
    Task<List<ReviewVM>> GetReviews();
    Task<ReviewVM> GetReview(int id);
    Task<Response<int>> UpdateReview(UpdateReviewVM review);
    Task<Response<int>> CreateReview(CreateReviewVM review);
    Task<Response<int>> DeleteReview(int id);
}
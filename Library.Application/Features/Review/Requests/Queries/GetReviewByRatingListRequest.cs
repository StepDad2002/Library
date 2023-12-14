using Library.Application.DTOs.Review;
using MediatR;

namespace Library.Application.Features.Review.Requests.Queries;

public class GetReviewByRatingListRequest : IRequest<List<ReviewDto>>
{
    public int MinRating { get; set; }
    public int? MaxRating { get; set; }
}
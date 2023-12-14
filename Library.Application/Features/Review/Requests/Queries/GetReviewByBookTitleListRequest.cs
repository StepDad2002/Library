using Library.Application.DTOs.Review;
using MediatR;

namespace Library.Application.Features.Review.Requests.Queries;

public class GetReviewByBookTitleListRequest : IRequest<List<ReviewDto>>
{
    public string BookTitle { get; set; }
}
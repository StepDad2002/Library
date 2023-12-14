using Library.Application.DTOs.Review;
using MediatR;

namespace Library.Application.Features.Review.Requests.Queries;

public class GetReviewByDateListRequest : IRequest<List<ReviewDto>>
{
    public DateTime Date { get; set; }
}
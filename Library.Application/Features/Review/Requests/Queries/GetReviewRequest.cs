using Library.Application.DTOs.Review;
using MediatR;

namespace Library.Application.Features.Review.Requests.Queries;

public class GetReviewRequest : IRequest<ReviewDto>
{
    public int Id { get; set; }
}
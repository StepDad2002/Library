using Library.Application.DTOs.Review;
using MediatR;

namespace Library.Application.Features.Review.Requests.Queries;

public class GetReviewListRequest : IRequest<List<ReviewDto>>
{
    
}
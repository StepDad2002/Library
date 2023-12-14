using Library.Application.DTOs.Review;
using MediatR;

namespace Library.Application.Features.Review.Requests.Queries;

public class GetReviewByCustomerPhoneListRequest : IRequest<List<ReviewDto>>
{
    public string Phone { get; set; }
}
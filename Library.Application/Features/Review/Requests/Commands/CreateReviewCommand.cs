using Library.Application.DTOs.Review;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Review.Requests.Commands;

public class CreateReviewCommand : IRequest<BaseCommandResponse>
{
    public CreateReviewDto Review { get; set; }
}
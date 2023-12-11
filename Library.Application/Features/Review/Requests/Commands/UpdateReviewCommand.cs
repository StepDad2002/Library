using Library.Application.DTOs.Review;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Review.Requests.Commands;

public class UpdateReviewCommand : IRequest<UpdateCommandResponse>
{
    public UpdateReviewDto Review { get; set; }
}
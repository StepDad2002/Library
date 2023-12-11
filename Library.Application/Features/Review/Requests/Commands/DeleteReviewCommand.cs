using MediatR;

namespace Library.Application.Features.Review.Requests.Commands;

public class DeleteReviewCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
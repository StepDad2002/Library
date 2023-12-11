using MediatR;

namespace Library.Application.Features.Book.Requests.Commands;

public class DeleteBookCommand : IRequest, IRequest<Unit>
{
    public int Id { get; set; }
}
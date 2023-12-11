using MediatR;

namespace Library.Application.Features.Shelf.Requests.Commands;

public class DeleteShelfCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
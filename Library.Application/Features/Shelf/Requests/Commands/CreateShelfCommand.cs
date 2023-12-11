using Library.Application.DTOs.Shelf;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Commands;

public class CreateShelfCommand : IRequest<BaseCommandResponse>
{
    public CreateShelfDto Shelf { get; set; }
}
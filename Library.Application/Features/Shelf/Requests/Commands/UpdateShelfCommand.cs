using Library.Application.DTOs.Shelf;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Commands;

public class UpdateShelfCommand : IRequest<UpdateCommandResponse>
{
    public UpdateShelfDto Shelf { get; set; }
}
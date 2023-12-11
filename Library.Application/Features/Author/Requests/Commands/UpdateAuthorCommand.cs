using Library.Application.DTOs.Author;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Author.Requests.Commands;

public class UpdateAuthorCommand : IRequest<UpdateCommandResponse>
{
    public UpdateAuthorDto? Author { get; set; }
}
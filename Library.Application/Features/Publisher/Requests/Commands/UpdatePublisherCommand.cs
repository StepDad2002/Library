using Library.Application.DTOs.Publisher;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Commands;

public class UpdatePublisherCommand : IRequest<UpdateCommandResponse>
{
    public UpdatePublisherDto Publisher { get; set; } = null!;
}
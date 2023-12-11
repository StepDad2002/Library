using Library.Application.DTOs.Publisher;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetPublisherByNameRequest : IRequest<PublisherDto>
{
    public string Name { get; set; }
}
using Library.Application.DTOs.Publisher;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetPublisherRequest : IRequest<PublisherDto>
{
    public int Id { get; set; }
}
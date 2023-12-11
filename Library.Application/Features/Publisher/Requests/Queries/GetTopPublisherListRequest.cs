using Library.Application.DTOs.Publisher;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetTopPublisherListRequest : IRequest<List<PublisherDto>>
{
    public int Limit { get; set; }
}
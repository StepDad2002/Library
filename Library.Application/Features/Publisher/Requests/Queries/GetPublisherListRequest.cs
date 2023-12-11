using Library.Application.DTOs.Publisher;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetPublisherListRequest : IRequest<List<PublisherDto>>
{
    
}
using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Publisher;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetTopPublisherListRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetTopPublisherListRequest,List<PublisherDto>>
{
    public async Task<List<PublisherDto>> Handle(GetTopPublisherListRequest request, CancellationToken cancellationToken)
    {
        var publisherList = await unitOfWork.PublisherRepository.GetTopPublishersWithDetailsAsync(request.Limit);
        
        
        return mapper.Map<List<PublisherDto>>(publisherList);
    }
}
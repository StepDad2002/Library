using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Publisher;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetPublisherListRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetPublisherListRequest,List<PublisherDto>>
{
    public async Task<List<PublisherDto>> Handle(GetPublisherListRequest request, CancellationToken cancellationToken)
    {
        var publisherList = await unitOfWork.PublisherRepository.GetPublishersWithDetailsAsync();
        
        
        return mapper.Map<List<PublisherDto>>(publisherList);
    }
}
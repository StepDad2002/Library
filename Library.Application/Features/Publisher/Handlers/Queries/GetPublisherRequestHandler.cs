using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Publisher;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetPublisherRequestHandler (IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<GetPublisherRequest,PublisherDto>
{
    public async Task<PublisherDto> Handle(GetPublisherRequest request, CancellationToken cancellationToken)
    {
        var publisher = await unitOfWork.PublisherRepository.GetPublisherWithDetailsAsync(request.Id);
        
        if (publisher is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Publisher), request.Id);
        
        return mapper.Map<PublisherDto>(publisher);
    }
}
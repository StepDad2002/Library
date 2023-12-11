using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Publisher;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Publisher.Requests.Queries;

public class GetPublisherByNameRequestHandler (IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<GetPublisherByNameRequest,PublisherDto>
{
    public async Task<PublisherDto> Handle(GetPublisherByNameRequest request, CancellationToken cancellationToken)
    {
        var publisher = await unitOfWork.PublisherRepository.GetPublisherWithDetailsAsync(request.Name);
        
        if (publisher is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Publisher), request.Name);
        
        return mapper.Map<PublisherDto>(publisher);
    }
}
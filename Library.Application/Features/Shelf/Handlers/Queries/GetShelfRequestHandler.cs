using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Shelf;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Queries;

public class GetShelfRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetShelfRequest,ShelfDto>
{
    public async Task<ShelfDto> Handle(GetShelfRequest request, CancellationToken cancellationToken)
    {
        var shelf = await unitOfWork.ShelfRepository.GetShelfWithDetailsAsync(request.Id);
        
        if (shelf == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Shelf), request.Id);
        
        return mapper.Map<ShelfDto>(shelf);
    }
}
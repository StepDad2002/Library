using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Shelf;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Queries;

public class GetShelfByNameRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetShelfByNameRequest,List<ShelfDto>>
{
    public async Task<List<ShelfDto>> Handle(GetShelfByNameRequest request, CancellationToken cancellationToken)
    {
        var shelf = await unitOfWork.ShelfRepository.GetShelfWithDetailsAsync(request.Name);
        
        if (shelf == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Shelf), request.Name);
        
        return mapper.Map<List<ShelfDto>>(shelf);
    }
}
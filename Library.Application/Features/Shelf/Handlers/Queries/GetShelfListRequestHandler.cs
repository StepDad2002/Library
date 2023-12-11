using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Shelf;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Queries;

public class GetShelfListRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetShelfListRequest,List<ShelfDto>>
{
    public async Task<List<ShelfDto>> Handle(GetShelfListRequest request, CancellationToken cancellationToken)
    {
        var shelfList = await unitOfWork.ShelfRepository.GetShelfsWithDetailsAsync();
        
        
        return mapper.Map<List<ShelfDto>>(shelfList);
    }
}
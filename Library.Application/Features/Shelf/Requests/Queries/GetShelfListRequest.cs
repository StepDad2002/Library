using Library.Application.DTOs.Shelf;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Queries;

public class GetShelfListRequest : IRequest<List<ShelfDto>>
{
    
}
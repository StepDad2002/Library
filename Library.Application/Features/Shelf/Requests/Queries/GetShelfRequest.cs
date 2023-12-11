using Library.Application.DTOs.Shelf;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Queries;

public class GetShelfRequest : IRequest<ShelfDto>
{
    public int Id { get; set; }
}

public class GetShelfByNameRequest : IRequest<List<ShelfDto>>
{
    public string Name { get; set; }
}
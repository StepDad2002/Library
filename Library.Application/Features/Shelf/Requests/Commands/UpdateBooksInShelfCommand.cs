using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Shelf.Requests.Commands;

public class UpdateBooksInShelfCommand : IRequest<UpdateCommandResponse>
{
    public int Id { get; set; }
    
    public ICollection<int> Books { get; set; }
}
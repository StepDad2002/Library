using Library.Application.DTOs.Book;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Book.Requests.Commands;

public class UpdateBookCommand : IRequest<UpdateCommandResponse>
{
    public int Id { get; set; }
    public UpdateBookDto Book { get; set; }

    public int? ShelfId { get; set; }
}
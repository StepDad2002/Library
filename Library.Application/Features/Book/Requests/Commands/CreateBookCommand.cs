using Library.Application.DTOs.Book;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Book.Requests.Commands;

public class CreateBookCommand : IRequest<BaseCommandResponse>
{
    public CreateBookDto Book { get; set; }
}
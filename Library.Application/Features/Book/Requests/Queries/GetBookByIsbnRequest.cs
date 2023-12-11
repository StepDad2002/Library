using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookByIsbnRequest : IRequest<BookDto>
{
    public string Isbn { get; set; }
}
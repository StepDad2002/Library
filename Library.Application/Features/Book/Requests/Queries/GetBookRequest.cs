using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookRequest : IRequest<BookDto>
{
    public int Id { get; set; }
}
using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookByGenreListRequest : IRequest<List<BookListDto>>
{
    public string Genre { get; set; }
}
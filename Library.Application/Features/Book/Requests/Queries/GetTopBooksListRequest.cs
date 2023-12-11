using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetTopBooksListRequest : IRequest<List<BookListDto>>
{
    public int Limit { get; set; }
}
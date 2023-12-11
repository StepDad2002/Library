using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookByTitleListRequest : IRequest<List<BookListDto>>
{
    public string Title { get; set; }
}
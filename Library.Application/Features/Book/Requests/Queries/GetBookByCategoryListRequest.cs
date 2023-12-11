using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookByCategoryListRequest : IRequest<List<BookListDto>>
{
    public string Category { get; set; }

}
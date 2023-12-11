using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookByLanguageListRequest : IRequest<List<BookListDto>>
{
    public string Language { get; set; }

}
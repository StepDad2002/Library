using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookByPublicationDateListRequest : IRequest<List<BookListDto>>
{
    public DateTime PublicationDate { get; set; }
}
using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookDetailedRequest : IRequest<BookDetailedDto>
{
    public int Id { get; set; }
}
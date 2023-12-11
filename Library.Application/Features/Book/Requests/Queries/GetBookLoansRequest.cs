using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookLoansRequest : IRequest<BookLoansDto>
{
    public int Id { get; set; }
}
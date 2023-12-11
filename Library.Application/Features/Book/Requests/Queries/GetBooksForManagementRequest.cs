using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBooksForManagementRequest : IRequest<List<BookDto>>
{

}
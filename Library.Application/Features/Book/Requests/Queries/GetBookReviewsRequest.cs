using Library.Application.DTOs.Book;
using MediatR;

namespace Library.Application.Features.Book.Requests.Queries;

public class GetBookReviewsRequest : IRequest<BookReviewsDto>
{
    public int Id { get; set; }
}
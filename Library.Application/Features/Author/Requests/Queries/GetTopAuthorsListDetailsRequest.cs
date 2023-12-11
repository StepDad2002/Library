using Library.Application.DTOs.Author;
using MediatR;

namespace Library.Application.Features.Author.Requests.Queries;

public class GetTopAuthorsListDetailsRequest : IRequest<List<AuthorDto>>
{
    public int Limit { get; set; }
}
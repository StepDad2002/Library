using Library.Application.DTOs.Author;
using MediatR;

namespace Library.Application.Features.Author.Requests.Queries;

public class GetAuthorByNameRequest : IRequest<List<AuthorDto>>
{
    public string Name { get; set; }
}
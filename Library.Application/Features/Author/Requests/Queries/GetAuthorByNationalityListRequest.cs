using Library.Application.DTOs.Author;
using MediatR;

namespace Library.Application.Features.Author.Requests.Queries;

public class GetAuthorByNationalityListRequest : IRequest<List<AuthorDto>>
{
    public string Nationality { get; set; }
}
using Library.Application.DTOs.Author;
using MediatR;

namespace Library.Application.Features.Author.Requests.Queries;

public class GetAuthorListDetailsRequest : IRequest<List<AuthorDto>>
{

}

public class GetAuthorByBirthdayListRequest : IRequest<List<AuthorDto>>
{
    public DateTime Birthday { get; set; }
}
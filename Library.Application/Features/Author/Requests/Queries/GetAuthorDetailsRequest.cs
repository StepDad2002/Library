using Library.Application.DTOs.Author;
using MediatR;

namespace Library.Application.Features.Author.Requests.Queries;

public class GetAuthorDetailsRequest : IRequest<AuthorDto>
{
    public int Id { get; set; }
}
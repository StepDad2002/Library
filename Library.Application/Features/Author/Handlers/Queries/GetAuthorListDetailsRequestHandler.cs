using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Author;
using Library.Application.Exeptions;
using Library.Application.Features.Author.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Author.Handlers.Queries;

public class GetAuthorListDetailsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetAuthorListDetailsRequest, List<AuthorDto>>
{
    public async Task<List<AuthorDto>> Handle(GetAuthorListDetailsRequest detailsRequest, CancellationToken cancellationToken)
    {
        var authors = await unitOfWork.AuthorRepository.GetAuthorsWithDetailsAsync();
        
        
        return mapper.Map<List<AuthorDto>>(authors);
        
    }
}
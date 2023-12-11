using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Author;
using Library.Application.Exeptions;
using Library.Application.Features.Author.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Author.Handlers.Queries;

public class GetTopAuthorsListDetailsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetTopAuthorsListDetailsRequest, List<AuthorDto>>
{
    public async Task<List<AuthorDto>> Handle(GetTopAuthorsListDetailsRequest detailsRequest, CancellationToken cancellationToken)
    {
        var authors = await unitOfWork.AuthorRepository.GetTopAuthorsWithDetailsAsync(detailsRequest.Limit);
        
     
        
        return mapper.Map<List<AuthorDto>>(authors);
        
    }
}
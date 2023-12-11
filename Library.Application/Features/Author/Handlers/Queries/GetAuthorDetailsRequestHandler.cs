using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Author;
using Library.Application.Exeptions;
using Library.Application.Features.Author.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Author.Handlers.Queries;

public class GetAuthorDetailsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetAuthorDetailsRequest, AuthorDto>
{
    public async Task<AuthorDto> Handle(GetAuthorDetailsRequest detailsRequest, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetAuthorWithDetailsAsync(detailsRequest.Id);
        
        if (author is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Author),detailsRequest.Id);
        
        return mapper.Map<AuthorDto>(author);
    }
}
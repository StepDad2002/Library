using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Author;
using Library.Application.Exeptions;
using Library.Application.Features.Author.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Author.Handlers.Queries;

public class GetAuthorByNameRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetAuthorByNameRequest, List<AuthorDto>>
{
    public async Task<List<AuthorDto>> Handle(GetAuthorByNameRequest detailsRequest, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetAuthorWithDetailsAsync(detailsRequest.Name);
        
        if (author is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Author),detailsRequest.Name);
        
        return mapper.Map<List<AuthorDto>>(author);
    }
}

public class GetAuthorByNationalityRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetAuthorByNationalityListRequest, List<AuthorDto>>
{
    public async Task<List<AuthorDto>> Handle(GetAuthorByNationalityListRequest detailsRequest, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetAuthorByNationalityDetailsAsync(detailsRequest.Nationality);
        
        if (author is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Author),detailsRequest.Nationality);
        
        return mapper.Map<List<AuthorDto>>(author);
    }
}

public class GetAuthorByBirthdayRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetAuthorByBirthdayListRequest, List<AuthorDto>>
{
    public async Task<List<AuthorDto>> Handle(GetAuthorByBirthdayListRequest detailsRequest, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetAuthorByBirthdayDetailsAsync(detailsRequest.Birthday);
        
        if (author is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Author),detailsRequest.Birthday.ToShortDateString());
        
        return mapper.Map<List<AuthorDto>>(author);
    }
}
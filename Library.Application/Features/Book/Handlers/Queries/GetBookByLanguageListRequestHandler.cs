using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookByLanguageListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBookByLanguageListRequest,List<BookListDto>>
{
    public async Task<List<BookListDto>> Handle(GetBookByLanguageListRequest request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookByLanguageDetailsAsync(request.Language);
        
        return mapper.Map<List<BookListDto>>(book);
    }
}
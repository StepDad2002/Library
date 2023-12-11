using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookByTitleRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBookByTitleListRequest,List<BookListDto>>
{
    public async Task<List<BookListDto>> Handle(GetBookByTitleListRequest request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookByTitleWithDetailsAsync(request.Title);
        
       
        
        return mapper.Map<List<BookListDto>>(book);
    }
}
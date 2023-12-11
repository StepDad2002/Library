using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetTopBooksListDetailsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetTopBooksListRequest, List<BookListDto>>
{
    public async Task<List<BookListDto>> Handle(GetTopBooksListRequest request, CancellationToken cancellationToken)
    {
        var books = await unitOfWork.BookRepository.GetTopBooksWithDetailsAsync(request.Limit);
        
      
        
        return mapper.Map<List<BookListDto>>(books);
    }
}
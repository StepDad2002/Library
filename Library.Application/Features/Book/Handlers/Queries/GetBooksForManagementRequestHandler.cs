using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBooksForManagementRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBooksForManagementRequest, List<BookDto>>
{
    public async Task<List<BookDto>> Handle(GetBooksForManagementRequest request, CancellationToken cancellationToken)
    {
        var books = await unitOfWork.BookRepository.GetBooksWithDetailsAsync();
        
        
        return mapper.Map<List<BookDto>>(books);
    }
}
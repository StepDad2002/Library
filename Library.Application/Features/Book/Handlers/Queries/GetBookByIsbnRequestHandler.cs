using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookByIsbnRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBookByIsbnRequest,BookDto>
{
    public async Task<BookDto> Handle(GetBookByIsbnRequest request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookByIsbnWithDetailsAsync(request.Isbn);
        
        if (book is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), request.Isbn);
        
        return mapper.Map<BookDto>(book);
    }
}
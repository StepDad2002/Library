using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBookRequest,BookDto>
{
    public async Task<BookDto> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookWithDetailsAsync(request.Id);
        
        if (book is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), request.Id);
        
        return mapper.Map<BookDto>(book);
    }
}
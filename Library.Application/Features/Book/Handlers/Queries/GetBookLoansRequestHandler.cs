using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookLoansRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetBookLoansRequest,BookLoansDto>
{
    public async Task<BookLoansDto> Handle(GetBookLoansRequest request, CancellationToken cancellationToken)
    {
        var bookLoans = await unitOfWork.BookRepository.GetBookWithLoansAsync(request.Id);
        
        if (bookLoans is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), request.Id);
        
        return mapper.Map<BookLoansDto>(bookLoans);
    }
}
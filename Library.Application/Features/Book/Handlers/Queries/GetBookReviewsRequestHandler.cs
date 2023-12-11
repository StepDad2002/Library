using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookReviewsRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
        IRequestHandler<GetBookReviewsRequest,BookReviewsDto>
{
    public async Task<BookReviewsDto> Handle(GetBookReviewsRequest request, CancellationToken cancellationToken)
    {
        var bookReviews = await unitOfWork.BookRepository.GetBookWithReviewsAsync(request.Id);
        
        if (bookReviews is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), request.Id);
        
        return mapper.Map<BookReviewsDto>(bookReviews);
    }
}
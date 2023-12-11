using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookByPublicationDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBookByPublicationDateListRequest,List<BookListDto>>
{
    public async Task<List<BookListDto>> Handle(GetBookByPublicationDateListRequest request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookByPublicationDateDetailsAsync(request.PublicationDate);
        
       
        return mapper.Map<List<BookListDto>>(book);
    }
}
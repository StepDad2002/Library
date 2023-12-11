using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookByCategoryListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBookByCategoryListRequest,List<BookListDto>>
{
    public async Task<List<BookListDto>> Handle(GetBookByCategoryListRequest request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookByCategoryDetailsAsync(request.Category);
        
        return mapper.Map<List<BookListDto>>(book);
    }
}
using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Queries;

public class GetBookByGenreListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetBookByGenreListRequest,List<BookListDto>>
{
    public async Task<List<BookListDto>> Handle(GetBookByGenreListRequest request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookByGenreDetailsAsync(request.Genre);
      
        return mapper.Map<List<BookListDto>>(book);
    }
}
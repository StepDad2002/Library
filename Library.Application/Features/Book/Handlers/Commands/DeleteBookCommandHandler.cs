using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Commands;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Commands;

public class DeleteBookCommandHandler (IUnitOfWork unitOfWork) :
    IRequestHandler<DeleteBookCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetBookWithLoansAsync(request.Id);

        if (book == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), request.Id);

        if (book.Loans?.Count > 0)
            throw new BadRequestException($"Can't delete Book [{book.Id}], because it has not closed loans");
        
        await unitOfWork.BookRepository.DeleteAsync(book);
        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.Shelf.Requests.Commands;
using MediatR;

namespace Library.Application.Features.Shelf.Handlers.Commands;

public class DeleteShelfCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<DeleteShelfCommand, Unit>
{
    public async Task<Unit> Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
    {
        var shelf = await unitOfWork.ShelfRepository.GetAsync(request.Id);
        
        if (shelf == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Shelf), request.Id);

        await unitOfWork.ShelfRepository.DeleteAsync(shelf);
        await unitOfWork.SaveAsync();
        
        return Unit.Value;
    }
}
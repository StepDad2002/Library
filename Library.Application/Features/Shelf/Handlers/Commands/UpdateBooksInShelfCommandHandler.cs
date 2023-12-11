using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Shelf.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Shelf.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Shelf.Handlers.Commands;

public class UpdateBooksInShelfCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<UpdateBooksInShelfCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateBooksInShelfCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateShelfBooksValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Books);
        
        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Books;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var shelf = await unitOfWork.ShelfRepository.GetAsync(request.Id);
            
            if (shelf == null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Shelf), request.Id);
            
            var books = await unitOfWork.BookRepository.GetBooksByIds(request.Books);
            
            shelf.Books = books;
            await unitOfWork.ShelfRepository.UpdateAsync(shelf);
            response.Message = "Update succeeded";
            await unitOfWork.SaveAsync();
            response.Id = shelf.Id;
        }

        return response;
    }
}
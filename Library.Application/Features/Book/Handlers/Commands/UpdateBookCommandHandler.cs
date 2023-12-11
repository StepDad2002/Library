using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Book.Requests.Commands;
using Library.Application.Responses;
using MediatR;

// ReSharper disable ConditionIsAlwaysTrueOrFalse


namespace Library.Application.Features.Book.Handlers.Commands;

public class UpdateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<UpdateBookCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        bool isValid = false;
        var book = await unitOfWork.BookRepository.GetBookWithAuthorsAsync(request.Id);

        if (book is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Book), request.Id);

        if (request.Book != null)
        {
            isValid = await InternalBookUpdateHandling(request, book, response);
        }

        if (request.ShelfId.HasValue)
        {
            isValid = await InternalBookShelfUpdateHandling(request.ShelfId.Value, book, response);
        }

        if (isValid)
            await unitOfWork.SaveAsync();

        return response;
    }

    private async Task<bool> InternalBookShelfUpdateHandling(int shelfId,
        Domain.Entities.Schemas.BookSchema.Book book, UpdateCommandResponse response)
    {
        var validator = new UpdateBookShelfValidator(unitOfWork.ShelfRepository);
        var validationResult = await validator.ValidateAsync(shelfId);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = new { Book = book, ShelfId = shelfId };
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            book.ShelfId = shelfId;
            await unitOfWork.BookRepository.UpdateAsync(book);
            response.Message = "Update succeeded";
            response.Id = book.Id;
        }

        return await Task.FromResult(validationResult.IsValid);
    }

    private async Task<bool> InternalBookUpdateHandling(UpdateBookCommand request,
        Domain.Entities.Schemas.BookSchema.Book book, UpdateCommandResponse response)
    {
        var validator = new UpdateBookDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Book);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Book;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var b = mapper.Map(request.Book, book);
            await unitOfWork.BookRepository.UpdateAsync(book);
            response.Message = "Update succeeded";
            response.Id = book.Id;
        }

        return await Task.FromResult(validationResult.IsValid);
    }
}
using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Shelf.Validators;

public class UpdateShelfBooksValidator: InlineValidator<ICollection<int>>
{
    public UpdateShelfBooksValidator(IUnitOfWork unitOfWork) 
    {
        RuleFor(booksId => booksId)
            .ForEach(id =>
                id.MustAsync(async (bookId, token) =>
                {
                    return await unitOfWork.BookRepository.ExistsAsync(bookId);
                }).WithMessage("One ore more book(s) does not exist"));
    }
}
using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.DTOs.Book.Validators;

public class UpdateBookShelfValidator : InlineValidator<int>
{
    
    public UpdateBookShelfValidator(IShelfRepository _shelfRepository)
    {
        RuleFor(x => x)
            .MustAsync(async (id, tok) =>
            {
                return await _shelfRepository.ExistsAsync(id);
            })
            .WithMessage("{PropertyName} does not exist")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater then 0");
    }
}
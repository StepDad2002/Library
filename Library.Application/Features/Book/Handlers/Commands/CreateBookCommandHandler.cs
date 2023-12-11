using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Book.Validators;
using Library.Application.Features.Book.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Book.Handlers.Commands;

public class CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<CreateBookCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new CreateBookDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Book);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var publisher = await unitOfWork.PublisherRepository.GetByPhoneAsync(request.Book.Publisher.Phone);
            var authors = new List<Domain.Entities.Schemas.BookSchema.Author>();
            var book = mapper.Map<Domain.Entities.Schemas.BookSchema.Book>(request.Book);


            await ProcessBookAuthorsAndPublisherInternal(request, authors, book, publisher);

            await unitOfWork.BookRepository.AddAsync(book);
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = book.Id;
        }

        return commandResponse;
    }

    private async Task ProcessBookAuthorsAndPublisherInternal(CreateBookCommand request,
        List<Domain.Entities.Schemas.BookSchema.Author> authors, Domain.Entities.Schemas.BookSchema.Book book,
        Domain.Entities.Schemas.BookSchema.Publisher? publisher)
    {
        foreach (var a in request.Book.Authors)
        {
            var author = await unitOfWork.AuthorRepository.GetByFullName(a.FName, a.LName, a.FName);
            if (author != null)
                authors.Add(author);
        }

        if (authors.Count > 0)
            book.Authors = authors;

        if (publisher != null)
            book.Publisher = publisher;
    } 
}
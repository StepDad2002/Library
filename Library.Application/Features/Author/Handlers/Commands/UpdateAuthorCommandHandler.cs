using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Author;
using Library.Application.Exeptions;
using Library.Application.Features.Author.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Author.Handlers.Commands;

public class UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<UpdateAuthorCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validationResult = await new UpdateAuthorDtoValidator().ValidateAsync(request.Author);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Author;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var author = await unitOfWork.AuthorRepository.GetAsync(request.Author.Id);

            if (author is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Author), request.Author.Id);
            
            mapper.Map(request.Author, author);
            await unitOfWork.AuthorRepository.UpdateAsync(author);
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = author.Id;
        }


        return response;
    }
}
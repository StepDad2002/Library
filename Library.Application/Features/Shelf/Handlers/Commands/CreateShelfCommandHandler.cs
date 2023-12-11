using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Shelf.Validators;
using Library.Application.Features.Shelf.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Shelf.Handlers.Commands;

public class CreateShelfCommandHandler (IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<CreateShelfCommand, BaseCommandResponse>
{

    public async Task<BaseCommandResponse> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new ShelfDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Shelf);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var shelf = mapper.Map<Domain.Entities.Schemas.BookSchema.Shelf>(request.Shelf);
            await unitOfWork.ShelfRepository.AddAsync(shelf);
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = shelf.Id;
        }

        return commandResponse;
    }
}
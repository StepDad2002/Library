using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Shelf.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Shelf.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Shelf.Handlers.Commands;

public class UpdateShelfCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<UpdateShelfCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateShelfDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Shelf);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Shelf;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var shelf = await unitOfWork.ShelfRepository.GetAsync(request.Shelf.Id);
            
            if (shelf == null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Shelf), request.Shelf.Id);
            
            mapper.Map(request.Shelf, shelf);
            await unitOfWork.ShelfRepository.UpdateAsync(shelf);
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = shelf.Id;
        }

        return response;
    }
}
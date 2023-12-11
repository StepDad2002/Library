using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Publisher.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Publisher.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Publisher.Handlers.Commands;

public class UpdatePublisherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdatePublisherCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdatePublisherDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Publisher);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Publisher;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {

            var publisher = await unitOfWork.PublisherRepository.GetAsync(request.Publisher.Id);

            if (publisher is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.BookSchema.Publisher), request.Publisher.Id);

            mapper.Map(request.Publisher, publisher);

            await unitOfWork.PublisherRepository.UpdateAsync(publisher);
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = publisher.Id;
        }

        return response;
    }
}
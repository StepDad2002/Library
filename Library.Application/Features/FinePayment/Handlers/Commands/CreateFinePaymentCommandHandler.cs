using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.FinePayment.Validators;
using Library.Application.Features.FinePayment.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.FinePayment.Handlers.Commands;

public class CreateFinePaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<CreateFinePaymentCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateFinePaymentCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new FinePaymentDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.FinePayment);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var payment = mapper.Map<Domain.Entities.Schemas.Management.FinePayment>(request.FinePayment);
            await unitOfWork.FinePaymentRepository.AddAsync(payment);
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = payment.Id;
        }

        return commandResponse;
    }
}
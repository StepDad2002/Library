using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer.Validators;
using Library.Application.Features.Customer.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Customer.Handlers.Commands;

public class CreateCustomerCommandHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<CreateCustomerCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new CreateCustomerValidator();
        var validationResult = await validator.ValidateAsync(request.Customer);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var customer = mapper.Map<Domain.Entities.Schemas.Management.Customer>(request.Customer);
            await unitOfWork.CustomerRepository.AddAsync(customer);
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = customer.Id;
        }

        return commandResponse;
    }
}
using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Customer.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Customer.Handlers.Commands;

public class UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<UpdateCustomerCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateCustomerValidator();
        var validationResult = await validator.ValidateAsync(request.Customer);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Customer;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var customer = await unitOfWork.CustomerRepository.GetAsync(request.Customer.Id);
            
            if (customer is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Customer.Id);
            
            mapper.Map(request.Customer, customer);
            await unitOfWork.CustomerRepository.UpdateAsync(customer);
            
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = customer.Id;
        }

        return response;
    }
}
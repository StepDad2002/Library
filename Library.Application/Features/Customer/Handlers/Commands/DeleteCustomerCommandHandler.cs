using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.Customer.Requests.Commands;
using MediatR;

namespace Library.Application.Features.Customer.Handlers.Commands;

public class DeleteCustomerCommandHandler (IUnitOfWork unitOfWork) :
    IRequestHandler<DeleteCustomerCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await unitOfWork.CustomerRepository.GetAsync(request.Id);
        
        if (customer == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Id);
        
        await unitOfWork.CustomerRepository.DeleteAsync(customer);
        await unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerRequest,CustomerDto>
{
    public async Task<CustomerDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer= await unitOfWork.CustomerRepository.GetAsync(request.Id);
        
        if (customer is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Id);
        
        return mapper.Map<CustomerDto>(customer);
    }
}

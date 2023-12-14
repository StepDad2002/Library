using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerByEmailRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerByEmailRequest,CustomerListDto>
{
    public async Task<CustomerListDto> Handle(GetCustomerByEmailRequest request, CancellationToken cancellationToken)
    {
        var customer = await unitOfWork.CustomerRepository.GetByEmailAsync(request.Email);
        
        if (customer is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Email);
        
        return mapper.Map<CustomerListDto>(customer);
    }
}
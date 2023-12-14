using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerByPhoneRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerByPhoneRequest,CustomerListDto>
{
    public async Task<CustomerListDto> Handle(GetCustomerByPhoneRequest request, CancellationToken cancellationToken)
    {
        var customer = await unitOfWork.CustomerRepository.GetByPhoneAsync(request.Phone);
        
        if (customer is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Phone);
        
        return mapper.Map<CustomerListDto>(customer);
    }
}
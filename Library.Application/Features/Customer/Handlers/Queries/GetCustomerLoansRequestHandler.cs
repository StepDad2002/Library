using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerLoansRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerLoansRequest,CustomerLoansDto>
{
    public async Task<CustomerLoansDto> Handle(GetCustomerLoansRequest request, CancellationToken cancellationToken)
    {
        var customerLoans = await unitOfWork.CustomerRepository.GetCustomerLoansAsync(request.Id);
        
        if (customerLoans is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Id);        
        
        return mapper.Map<CustomerLoansDto>(customerLoans);
    }
}
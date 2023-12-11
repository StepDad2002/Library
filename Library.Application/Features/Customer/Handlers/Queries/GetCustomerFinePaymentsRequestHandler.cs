using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerFinePaymentsRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerFinePaymentsRequest,CustomerFinePaymentsDto>
{
    public async Task<CustomerFinePaymentsDto> Handle(GetCustomerFinePaymentsRequest request, CancellationToken cancellationToken)
    {
        var customerPayments = await unitOfWork.CustomerRepository.GetCustomerFinePaymentsAsync(request.Id);
        
        if (customerPayments is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Id);
        
        return mapper.Map<CustomerFinePaymentsDto>(customerPayments);
    }
}
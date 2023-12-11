using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerReservationsRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerReservationsRequest,CustomerReservationsDto>
{
    public async Task<CustomerReservationsDto> Handle(GetCustomerReservationsRequest request, CancellationToken cancellationToken)
    {
        var customerReservations = await unitOfWork.CustomerRepository.GetCustomerReservationsAsync(request.Id);
        
        if (customerReservations is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Id);
        
        return mapper.Map<CustomerReservationsDto>(customerReservations);
    }
}
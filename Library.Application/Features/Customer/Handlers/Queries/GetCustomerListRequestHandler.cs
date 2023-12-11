using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerListRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerListRequest, List<CustomerListDto>>
{
    public async Task<List<CustomerListDto>> Handle(GetCustomerListRequest request, CancellationToken cancellationToken)
    {
        var customers = await unitOfWork.CustomerRepository.GetAllAsync();
        
        return mapper.Map<List<CustomerListDto>>(customers);
    }
}
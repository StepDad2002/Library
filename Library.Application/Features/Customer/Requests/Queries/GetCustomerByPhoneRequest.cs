using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerByPhoneRequest : IRequest<CustomerListDto>
{
    public string Phone { get; set; }
}
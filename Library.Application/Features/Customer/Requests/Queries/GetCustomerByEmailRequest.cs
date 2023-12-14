using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerByEmailRequest : IRequest<CustomerListDto>
{
    public string Email { get; set; }
}
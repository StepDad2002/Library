using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerRequest : IRequest<CustomerDto>
{
    public int Id { get; set; }
}

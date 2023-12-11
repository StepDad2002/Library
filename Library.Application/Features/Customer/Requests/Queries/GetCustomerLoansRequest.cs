using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerLoansRequest : IRequest<CustomerLoansDto>
{
    public int Id { get; set; }
}
using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerFinePaymentsRequest : IRequest<CustomerFinePaymentsDto>
{
    public int Id { get; set; }
}
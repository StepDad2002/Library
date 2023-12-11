using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerReservationsRequest : IRequest<CustomerReservationsDto>
{
    public int Id { get; set; }
}
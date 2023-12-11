using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerReviewsRequest : IRequest<CustomerReviewsDto>
{
    public int Id { get; set; }
}
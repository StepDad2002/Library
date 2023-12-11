using Library.Application.DTOs.Customer;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerListRequest : IRequest<List<CustomerListDto>>
{

}
using Library.Application.DTOs.Customer;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Commands;

public class CreateCustomerCommand : IRequest<BaseCommandResponse>
{
    public CreateCustomerDto Customer { get; set; }
}
using Library.Application.DTOs.Customer;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Commands;

public class UpdateCustomerCommand : IRequest<UpdateCommandResponse>
{
    public UpdateCustomerDto Customer { get; set; }
}
using MediatR;

namespace Library.Application.Features.Customer.Requests.Commands;

public class DeleteCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
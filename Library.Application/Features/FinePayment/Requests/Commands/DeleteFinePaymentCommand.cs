using MediatR;

namespace Library.Application.Features.FinePayment.Requests.Commands;

public class DeleteFinePaymentCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
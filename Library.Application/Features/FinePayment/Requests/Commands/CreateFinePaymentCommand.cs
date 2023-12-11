using Library.Application.DTOs.FinePayment;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.FinePayment.Requests.Commands;

public class CreateFinePaymentCommand : IRequest<BaseCommandResponse>
{
    public CreateFinePaymentDto FinePayment { get; set; }
}
using Library.Application.DTOs.FinePayment;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.FinePayment.Requests.Commands;

public class UpdateFinePaymentCommand : IRequest<UpdateCommandResponse>
{
    public UpdateFinePaymentDto FinePayment { get; set; }
}
using Library.Application.DTOs.FinePayment;
using MediatR;

namespace Library.Application.Features.FinePayment.Requests.Queries;

public class GetFinePaymentRequest : IRequest<FinePaymentDto>
{
    public int Id { get; set; }
}
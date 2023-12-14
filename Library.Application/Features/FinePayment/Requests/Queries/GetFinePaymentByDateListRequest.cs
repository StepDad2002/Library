using Library.Application.DTOs.FinePayment;
using MediatR;

namespace Library.Application.Features.FinePayment.Requests.Queries;

public class GetFinePaymentByDateListRequest : IRequest<List<FinePaymentListDto>>
{
    public DateTime PayedOn { get; set; }
}
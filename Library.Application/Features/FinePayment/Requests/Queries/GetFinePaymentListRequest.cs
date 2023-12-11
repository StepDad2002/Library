using Library.Application.DTOs.FinePayment;
using MediatR;

namespace Library.Application.Features.FinePayment.Requests.Queries;

public class GetFinePaymentListRequest : IRequest<List<FinePaymentListDto>>
{
    
}
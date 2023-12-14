using Library.Application.DTOs.FinePayment;
using MediatR;

namespace Library.Application.Features.FinePayment.Requests.Queries;

public class GetFinePaymentByCustomerPhoneListRequest : IRequest<List<FinePaymentListDto>>
{
    public string Phone { get; set; }
}
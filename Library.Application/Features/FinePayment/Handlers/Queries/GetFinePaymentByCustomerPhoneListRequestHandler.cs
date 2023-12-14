using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.FinePayment;
using Library.Application.Features.FinePayment.Requests.Queries;
using MediatR;

namespace Library.Application.Features.FinePayment.Handlers.Queries;

public class GetFinePaymentByCustomerPhoneListRequestHandler(IUnitOfWork unitOfWork, IMapper _mapper) :
    IRequestHandler<GetFinePaymentByCustomerPhoneListRequest, List<FinePaymentListDto>>
{
    public async Task<List<FinePaymentListDto>> Handle(GetFinePaymentByCustomerPhoneListRequest request, CancellationToken cancellationToken)
    {
        var finePayment = await unitOfWork.FinePaymentRepository.GetFinePaymentsByCustomerPhoneAsync(request.Phone);
        
       
        var payment = _mapper.Map<List<FinePaymentListDto>>(finePayment);
        return payment;
    }
}
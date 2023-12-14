using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.FinePayment;
using Library.Application.Features.FinePayment.Requests.Queries;
using MediatR;

namespace Library.Application.Features.FinePayment.Handlers.Queries;

public class GetFinePaymentByDateListRequestHandler(IUnitOfWork unitOfWork, IMapper _mapper) :
    IRequestHandler<GetFinePaymentByDateListRequest, List<FinePaymentListDto>>
{
    public async Task<List<FinePaymentListDto>> Handle(GetFinePaymentByDateListRequest request, CancellationToken cancellationToken)
    {
        var finePayment = await unitOfWork.FinePaymentRepository.GetFinePaymentsByDateAsync(request.PayedOn);
        
       
        var payment = _mapper.Map<List<FinePaymentListDto>>(finePayment);
        return payment;
    }
}
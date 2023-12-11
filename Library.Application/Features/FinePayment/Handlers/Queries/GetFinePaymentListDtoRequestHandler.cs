using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.FinePayment;
using Library.Application.Exeptions;
using Library.Application.Features.FinePayment.Requests.Queries;
using MediatR;

namespace Library.Application.Features.FinePayment.Handlers.Queries;

public class GetFinePaymentListDtoRequestHandler(IUnitOfWork unitOfWork, IMapper _mapper) :
    IRequestHandler<GetFinePaymentListRequest, List<FinePaymentListDto>>
{
    public async Task<List<FinePaymentListDto>> Handle(GetFinePaymentListRequest request, CancellationToken cancellationToken)
    {
        var finePayment = await unitOfWork.FinePaymentRepository.GetFinePaymentsWithDetailsAsync();
        
       
         var payment = _mapper.Map<List<FinePaymentListDto>>(finePayment);
         return payment;
    }
}
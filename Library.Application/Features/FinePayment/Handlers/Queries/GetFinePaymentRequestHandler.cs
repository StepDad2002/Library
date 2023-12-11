using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.FinePayment;
using Library.Application.Exeptions;
using Library.Application.Features.FinePayment.Requests.Queries;
using MediatR;

namespace Library.Application.Features.FinePayment.Handlers.Queries;

public class GetFinePaymentRequestHandler (IUnitOfWork unitOfWork, IMapper _mapper): 
    IRequestHandler<GetFinePaymentRequest, FinePaymentDto>
{
    public async Task<FinePaymentDto> Handle(GetFinePaymentRequest request, CancellationToken cancellationToken)
    {
        var finePayment = await unitOfWork.FinePaymentRepository.GetFinePaymentWithDetailsAsync(request.Id);
        
        if (finePayment is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.FinePayment),request.Id);        
        
        return _mapper.Map<FinePaymentDto>(finePayment);
    }
}
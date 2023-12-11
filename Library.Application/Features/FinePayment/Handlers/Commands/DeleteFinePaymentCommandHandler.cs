using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.FinePayment.Requests.Commands;
using MediatR;

namespace Library.Application.Features.FinePayment.Handlers.Commands;

public class DeleteFinePaymentCommandHandler (IUnitOfWork unitOfWork):
    IRequestHandler<DeleteFinePaymentCommand, Unit>
{
    public async Task<Unit> Handle(DeleteFinePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await unitOfWork.FinePaymentRepository.GetAsync(request.Id);
        
        if (payment == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.FinePayment), request.Id);

        await unitOfWork.FinePaymentRepository.DeleteAsync(payment);
        
        await unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
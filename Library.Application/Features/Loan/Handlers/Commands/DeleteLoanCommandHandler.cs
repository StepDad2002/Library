using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.Loan.Requests.Commands;
using MediatR;

namespace Library.Application.Features.Loan.Handlers.Commands;

public class DeleteLoanCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteLoanCommand, Unit>
{
    public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetAsync(request.Id);
        
        if (loan == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Loan), request.Id);

        var payment = new Domain.Entities.Schemas.Management.FinePayment()
        {
            Amount = loan.FineAmount,
            CustomerId = loan.CustomerId.Value,
            PaymentDate = DateTime.Now
        };

        await unitOfWork.FinePaymentRepository.AddAsync(payment);

        await unitOfWork.LoanRepository.DeleteAsync(loan);
        await unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanRequestHandler (IUnitOfWork unitOfWork, IMapper mapper): 
    IRequestHandler<GetLoanRequest,LoanDto>
{
    public async Task<LoanDto> Handle(GetLoanRequest request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetLoanWithDetailsAsync(request.Id);
        
        if (loan == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Loan), request.Id);
        
        return mapper.Map<LoanDto>(loan);
    }
}
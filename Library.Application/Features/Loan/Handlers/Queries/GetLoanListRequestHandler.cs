using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetLoanListRequest, List<LoanListDto>>
{
    public async Task<List<LoanListDto>> Handle(GetLoanListRequest request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetLoansWithDetailsAsync();
        
       
        return mapper.Map<List<LoanListDto>>(loan);
    }
}
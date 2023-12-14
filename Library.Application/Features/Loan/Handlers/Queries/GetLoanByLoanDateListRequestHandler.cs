using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByLoanDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetLoanByLoanDateListRequest, List<LoanListDto>>
{
    public async Task<List<LoanListDto>> Handle(GetLoanByLoanDateListRequest request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetLoansByLoanDateAsync(request.LoanDate);
        
       
        return mapper.Map<List<LoanListDto>>(loan);
    }
}
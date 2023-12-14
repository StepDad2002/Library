using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByDueDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetLoanByDueDateListRequest, List<LoanListDto>>
{
    public async Task<List<LoanListDto>> Handle(GetLoanByDueDateListRequest request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetLoansByDueDateAsync(request.DueDate);
        
       
        return mapper.Map<List<LoanListDto>>(loan);
    }
}
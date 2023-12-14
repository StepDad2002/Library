using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByReturnedDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetLoanByReturnedDateListRequest, List<LoanListDto>>
{
    public async Task<List<LoanListDto>> Handle(GetLoanByReturnedDateListRequest request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetLoansByReturnedDateAsync(request.ReturnedDate);
        
       
        return mapper.Map<List<LoanListDto>>(loan);
    }
}
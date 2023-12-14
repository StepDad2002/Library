using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByBookTitleListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetLoanByBookTitleListRequest, List<LoanListDto>>
{
    public async Task<List<LoanListDto>> Handle(GetLoanByBookTitleListRequest request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetLoansByBookTitleAsync(request.BookTitle);
        
       
        return mapper.Map<List<LoanListDto>>(loan);
    }
}
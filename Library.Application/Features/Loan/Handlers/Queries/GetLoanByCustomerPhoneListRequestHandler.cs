using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByCustomerPhoneListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetLoanByCustomerPhoneListRequest, List<LoanListDto>>
{
    public async Task<List<LoanListDto>> Handle(GetLoanByCustomerPhoneListRequest request, CancellationToken cancellationToken)
    {
        var loan = await unitOfWork.LoanRepository.GetLoansByCustomerPhoneAsync(request.Phone);
        
       
        return mapper.Map<List<LoanListDto>>(loan);
    }
}
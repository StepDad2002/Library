using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByLoanDateListRequest : IRequest<List<LoanListDto>>
{
    public DateTime LoanDate { get; set; }
}
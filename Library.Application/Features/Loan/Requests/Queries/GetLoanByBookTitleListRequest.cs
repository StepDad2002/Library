using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByBookTitleListRequest : IRequest<List<LoanListDto>>
{
    public string BookTitle { get; set; }
}
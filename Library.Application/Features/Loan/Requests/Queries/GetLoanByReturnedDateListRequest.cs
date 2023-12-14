using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByReturnedDateListRequest : IRequest<List<LoanListDto>>
{
    public DateTime ReturnedDate { get; set; }
}
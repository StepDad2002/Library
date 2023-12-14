using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByDueDateListRequest : IRequest<List<LoanListDto>>
{
    public DateTime DueDate { get; set; }
}
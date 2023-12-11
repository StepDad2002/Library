using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanRequest : IRequest<LoanDto>
{
    public int Id { get; set; }
}
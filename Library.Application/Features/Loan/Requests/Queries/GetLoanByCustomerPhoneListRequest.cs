using Library.Application.DTOs.Loan;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Queries;

public class GetLoanByCustomerPhoneListRequest : IRequest<List<LoanListDto>>
{
    public string Phone { get; set; }
}
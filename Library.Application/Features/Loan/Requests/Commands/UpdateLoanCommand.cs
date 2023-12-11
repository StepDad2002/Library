using Library.Application.DTOs.Loan;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Commands;

public class UpdateLoanCommand : IRequest<UpdateCommandResponse>
{
    public UpdateLoanDto Loan { get; set; }
}
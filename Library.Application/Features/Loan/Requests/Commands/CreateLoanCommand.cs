using Library.Application.DTOs.Loan;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Loan.Requests.Commands;

public class CreateLoanCommand : IRequest<BaseCommandResponse>
{
    public CreateLoanDto Loan { get; set; }
}


using MediatR;

namespace Library.Application.Features.Loan.Requests.Commands;

public class DeleteLoanCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
using MediatR;

namespace Library.Application.Features.Staff.Requests.Commands;

public class DeleteStaffCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
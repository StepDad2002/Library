using Library.Application.DTOs;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffByEmailRequest : IRequest<StaffListDto>
{
    public string Email { get; set; }
}
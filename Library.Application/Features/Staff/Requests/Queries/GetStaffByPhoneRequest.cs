using Library.Application.DTOs;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffByPhoneRequest : IRequest<StaffListDto>
{
    public string Phone { get; set; }
}
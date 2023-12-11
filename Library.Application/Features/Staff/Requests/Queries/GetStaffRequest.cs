using Library.Application.DTOs;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffRequest : IRequest<StaffDto>
{
    public int Id { get; set; }
}
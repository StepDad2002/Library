using Library.Application.DTOs;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffListRequest : IRequest<List<StaffListDto>>
{
    
}
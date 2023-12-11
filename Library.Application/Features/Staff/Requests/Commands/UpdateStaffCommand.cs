using Library.Application.DTOs;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Commands;

public class UpdateStaffCommand : IRequest<UpdateCommandResponse>
{
    public UpdateStaffDto Staff { get; set; }
}
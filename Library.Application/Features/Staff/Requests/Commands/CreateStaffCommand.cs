using Library.Application.DTOs;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Commands;

public class CreateStaffCommand : IRequest<BaseCommandResponse>
{
    public CreateStaffDto Staff { get; set; }
}
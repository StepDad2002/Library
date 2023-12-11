using Library.Application.DTOs;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Commands;

public class StaffLoginCommand : IRequest<BaseCommandResponse>
{
    public LogInDto Login { get; set; }
}
using Library.Application.DTOs;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Commands;

public class CustomerLoginCommand : IRequest<BaseCommandResponse>
{
    public LogInDto Login { get; set; }
}
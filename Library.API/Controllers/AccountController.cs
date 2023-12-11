using Library.Application.DTOs;
using Library.Application.Features.Customer.Requests.Commands;
using Library.Application.Features.Staff.Requests.Commands;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost("log-cus")]
    public async Task<ActionResult<BaseCommandResponse>> LogInCustomer(LogInDto login)
    {
        var response = await mediator.Send(new CustomerLoginCommand() { Login = login });

        return Ok(response);
    }
    
    [HttpPost("log-stf")]
    public async Task<ActionResult<BaseCommandResponse>> LogInStaff(LogInDto login)
    {
        var response = await mediator.Send(new StaffLoginCommand() { Login = login });

        return Ok(response);
    }
}
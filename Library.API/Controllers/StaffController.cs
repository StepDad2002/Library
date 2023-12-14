using Library.Application.DTOs;
using Library.Application.Features.Staff.Requests.Commands;
using Library.Application.Features.Staff.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController(IMediator _mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<StaffDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetStaffRequest() { Id = id });
        return Ok(response);
    }
    
    [HttpGet("search/phone")]
    public async Task<ActionResult<StaffListDto>> GetByPhone(string phone)
    {
        var response = await _mediator.Send(new GetStaffByPhoneRequest() { Phone = phone });
        return Ok(response);
    }
    
    [HttpGet("search/email")]
    public async Task<ActionResult<StaffListDto>> GetByEmail(string email)
    {
        var response = await _mediator.Send(new GetStaffByEmailRequest() { Email = email });
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<StaffListDto>>> Get()
    {
        var response = await _mediator.Send(new GetStaffListRequest());
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateStaffDto payment)
    {
        var command = new CreateStaffCommand() { Staff = payment };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateStaffDto staff)
    {
        var command = new UpdateStaffCommand() { Staff = staff };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteStaffCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
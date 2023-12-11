using Library.Application.DTOs.Loan;
using Library.Application.Features.Loan.Requests.Commands;
using Library.Application.Features.Loan.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<LoanListDto>>> Get()
    {
        var response = await _mediator.Send(new GetLoanListRequest());
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<LoanDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetLoanRequest(){Id = id});
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLoanDto loan)
    {
        var command = new CreateLoanCommand() { Loan = loan };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateLoanDto loan)
    {
        var command = new UpdateLoanCommand() { Loan = loan };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLoanCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
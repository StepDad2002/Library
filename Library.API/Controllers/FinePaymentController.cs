using Library.Application.DTOs.FinePayment;
using Library.Application.Features.FinePayment.Requests.Commands;
using Library.Application.Features.FinePayment.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinePaymentController(IMediator _mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<FinePaymentDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetFinePaymentRequest() { Id = id });
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<FinePaymentListDto>>> Get()
    {
        var response = await _mediator.Send(new GetFinePaymentListRequest());
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFinePaymentDto payment)
    {
        var command = new CreateFinePaymentCommand() { FinePayment = payment };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateFinePaymentDto payment)
    {
        var command = new UpdateFinePaymentCommand() { FinePayment = payment };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFinePaymentCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    
}
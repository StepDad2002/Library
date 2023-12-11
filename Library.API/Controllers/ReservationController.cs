using Library.Application.DTOs.Reservation;
using Library.Application.Features.Reservation.Requests.Commands;
using Library.Application.Features.Reservation.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ReservationListDto>>> Get()
    {
        var response = await _mediator.Send(new GetReservationListRequest());
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetReservationRequest(){Id = id});
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReservationDto reservation)
    {
        var command = new CreateReservationCommand() { Reservation = reservation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateReservationDto reservation)
    {
        var command = new UpdateReservationCommand() { Reservation = reservation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReservationCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
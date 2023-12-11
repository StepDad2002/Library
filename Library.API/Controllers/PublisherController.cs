using Library.Application.DTOs.Publisher;
using Library.Application.Features.Publisher.Requests.Commands;
using Library.Application.Features.Publisher.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PublisherDto>>> Get()
    {
        var response = await _mediator.Send(new GetPublisherListRequest());
        return Ok(response);
    }
    
    [HttpGet("top")]
    public async Task<ActionResult<List<PublisherDto>>> GetTop(int limit = 5)
    {
        var response = await _mediator.Send(new GetTopPublisherListRequest(){Limit = limit});
        return Ok(response);
    }
    
 
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetPublisherRequest(){Id = id});
        return Ok(response);
    }
    
    [HttpGet("search")]
    public async Task<ActionResult<PublisherDto>> Get(string name)
    {
        var response = await _mediator.Send(new GetPublisherByNameRequest(){Name = name});
        return Ok(response);
    }
    
   
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdatePublisherDto pub)
    {
        var command = new UpdatePublisherCommand() { Publisher = pub };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
}
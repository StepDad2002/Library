using Library.Application.DTOs.Shelf;
using Library.Application.Features.Shelf.Requests.Commands;
using Library.Application.Features.Shelf.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShelfController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ShelfDto>>> Get()
    {
        var response = await _mediator.Send(new GetShelfListRequest());
        return Ok(response);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<ShelfDto>>> Get(string name)
    {
        var response = await _mediator.Send(new GetShelfByNameRequest(){Name = name});
    return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ShelfDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetShelfRequest(){Id = id});
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateShelfDto shelf)
    {
        var command = new CreateShelfCommand() { Shelf = shelf };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateShelfDto shelf)
    {
        var command = new UpdateShelfCommand() { Shelf = shelf };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPut("put-books/{id}")]
    public async Task<ActionResult<UpdateCommandResponse>> Put(int id, [FromBody] ICollection<int> bookIds)
    {
        var command = new UpdateBooksInShelfCommand() { Books = bookIds, Id = id };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteShelfCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
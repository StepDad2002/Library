using Library.Application.DTOs.Author;
using Library.Application.Features.Author.Requests.Commands;
using Library.Application.Features.Author.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<AuthorDto>>> Get()
    {
        var response = await _mediator.Send(new GetAuthorListDetailsRequest());
        return Ok(response);
    }
    
    [HttpGet("/top")]
    public async Task<ActionResult<List<AuthorDto>>> GetTop(int limit = 5)
    {
        var response = await _mediator.Send(new GetTopAuthorsListDetailsRequest() {Limit = limit});
        return Ok(response);
    }
    
    [HttpGet("search/name")]
    public async Task<ActionResult<List<AuthorDto>>> Get(string name)
    {
        var response = await _mediator.Send(new GetAuthorByNameRequest() {Name = name});
        return Ok(response);
    }
    
    [HttpGet("search/nationality")]
    public async Task<ActionResult<List<AuthorDto>>> GetByNationality(string nationality)
    {
        var response = await _mediator.Send(new GetAuthorByNationalityListRequest() {Nationality = nationality});
        return Ok(response);
    }
    
    [HttpGet("search/birthday")]
    public async Task<ActionResult<List<AuthorDto>>> Get(DateTime birthday)
    {
        var response = await _mediator.Send(new GetAuthorByBirthdayListRequest() {Birthday = birthday});
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetAuthorDetailsRequest() {Id = id});
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateAuthorDto author)
    {
        var response = await _mediator.Send(new UpdateAuthorCommand(){Author = author});
        return Ok(response);
    }
    
}
using Library.Application.DTOs.Review;
using Library.Application.Features.Review.Requests.Commands;
using Library.Application.Features.Review.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController(IMediator _mediator): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetReviewRequest() { Id = id });
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ReviewDto>>> Get()
    {
        var response = await _mediator.Send(new GetReviewListRequest());
        return Ok(response);
    }
    
    [HttpGet("search/date")]
    public async Task<ActionResult<List<ReviewDto>>> GetByReviewDate(DateTime date)
    {
        var response = await _mediator.Send(new GetReviewByDateListRequest() {Date = date});
        return Ok(response);
    }
    
    [HttpGet("search/cust-phone")]
    public async Task<ActionResult<List<ReviewDto>>> GetByCustomerPhone(string phone)
    {
        var response = await _mediator.Send(new GetReviewByCustomerPhoneListRequest() {Phone = phone});
        return Ok(response);
    }
    
    [HttpGet("search/book-title")]
    public async Task<ActionResult<List<ReviewDto>>> GetByBookTitle(string title)
    {
        var response = await _mediator.Send(new GetReviewByBookTitleListRequest() {BookTitle = title});
        return Ok(response);
    }
    
    [HttpGet("search/rating")]
    public async Task<ActionResult<List<ReviewDto>>> GetByRating(int minRating, int? maxRating)
    {
        var response = await _mediator.Send(new GetReviewByRatingListRequest() {MinRating = minRating, MaxRating = maxRating});
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReviewDto review)
    {
        var command = new CreateReviewCommand() { Review = review };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpPut]
    public async Task<ActionResult<UpdateCommandResponse>> Put([FromBody] UpdateReviewDto review)
    {
        var command = new UpdateReviewCommand() { Review = review };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
   
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReviewCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
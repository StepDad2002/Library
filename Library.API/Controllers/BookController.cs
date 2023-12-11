using Library.Application.DTOs.Book;
using Library.Application.Features.Book.Requests.Commands;
using Library.Application.Features.Book.Requests.Queries;
using Library.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<BookListDto>>> Get()
    {
        var response = await _mediator.Send(new GetBookListRequest());
        return Ok(response);
    }
    
    [HttpGet("management/books")]
    public async Task<ActionResult<List<BookDto>>> BookListForManagement()
    {
        var response = await _mediator.Send(new GetBooksForManagementRequest());
        return Ok(response);
    }

    
    [HttpGet("top")]
    public async Task<ActionResult<List<BookListDto>>> GetTop(int limit = 5)
    {
       var response = await _mediator.Send(new GetTopBooksListRequest() {Limit = limit});
        return Ok(response);
    }
    
    [HttpGet("search/title")]
    public async Task<ActionResult<List<BookListDto>>> GetByTitle(string title)
    {
        var response = await _mediator.Send(new GetBookByTitleListRequest{Title = title});
        return Ok(response);
    }
    
    [HttpGet("search/category")]
    public async Task<ActionResult<List<BookListDto>>> GetByCategory(string category)
    {
        var response = await _mediator.Send(new GetBookByCategoryListRequest(){Category = category});
        return Ok(response);
    }
    
    [HttpGet("search/genre")]
    public async Task<ActionResult<List<BookListDto>>> GetByGenre(string genre)
    {
        var response = await _mediator.Send(new GetBookByGenreListRequest(){Genre = genre});
        return Ok(response);
    }
    
    [HttpGet("search/isbn")]
    public async Task<ActionResult<BookDto>> GetByIsbn(string isbn)
    {
        var response = await _mediator.Send(new GetBookByIsbnRequest(){Isbn = isbn});
        return Ok(response);
    }
    
    [HttpGet("search/language")]
    public async Task<ActionResult<List<BookListDto>>> GetByLanguage(string lang)
    {
        var response = await _mediator.Send(new GetBookByLanguageListRequest(){Language = lang});
        return Ok(response);
    }
    
    [HttpGet("search/publication-date")]
    public async Task<ActionResult<List<BookListDto>>> GetByLanguage(DateTime date)
    {
        var response = await _mediator.Send(new GetBookByPublicationDateListRequest(){PublicationDate = date});
        return Ok(response);
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> Get(int id)
    {
        var response = await _mediator.Send(new GetBookRequest(){Id = id});
        return Ok(response);
    }
    
    [HttpGet("/book-detailed/{id}")]
    public async Task<ActionResult<BookDetailedDto>> GetBookDetailed(int id)
    {
        var response = await _mediator.Send(new GetBookDetailedRequest() {Id = id});
        return Ok(response);
    }
    
    [HttpGet("/book-reviews/{id}")]
    public async Task<ActionResult<BookReviewsDto>> GetBookReviews(int id)
    {
        var response = await _mediator.Send(new GetBookReviewsRequest(){Id = id});
        return Ok(response);
    }
    
    [HttpGet("/book-loans/{id}")]
    public async Task<ActionResult<BookLoansDto>> GetBookLoans(int id)
    {
        var response = await _mediator.Send(new GetBookLoansRequest(){Id = id});
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post(CreateBookDto book)
    {
        var response = await _mediator.Send(new CreateBookCommand(){Book = book});
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateCommandResponse>> Put(int id,UpdateBookDto blyad)
    {
        var response = await _mediator.Send(new UpdateBookCommand() { Book = blyad, Id = id});
        return Ok(response);
    }
    [HttpPut("/replace-book")]
    public async Task<ActionResult<UpdateCommandResponse>> PutShelf(int id, int shelfId)
    {
        var response = await _mediator.Send(new UpdateBookCommand() { ShelfId = shelfId, Id = id});
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var response = await _mediator.Send(new DeleteBookCommand(){Id = id});
        return NoContent();
    }
}
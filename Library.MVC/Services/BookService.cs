using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.Book;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class BookService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), IBookService
{
    public async Task<List<BookListVM>> GetBooks()
    {
        var bookDtos = await _client.BookAllAsync();
        return mapper.Map<List<BookListVM>>(bookDtos);
    }

    public async Task<List<BookVM>> GetBooksForManagement()
    {
        var bookDtos = await _client.BooksAsync();
        return mapper.Map<List<BookVM>>(bookDtos);
    }

    public async Task<BookVM> GetBook(int id)
    {
        var bookDto = await _client.BookGETAsync(id);
        return mapper.Map<BookVM>(bookDto);
    }
    public async Task<List<BookListVM>> GetBooksByTitle(string title)
    {
        var bookDto = await _client.TitleAsync(title);
        return mapper.Map<List<BookListVM>>(bookDto);
    }
    public async Task<BookDetailedVM> GetBookDetailed(int id)
    {
        var bookDto = await _client.BookDetailedAsync(id);
        return mapper.Map<BookDetailedVM>(bookDto);
    }

    public async Task<BookLoansVM> GetBookLoans(int id)
    {
        var bookDto = await _client.BookLoansAsync(id);
        return mapper.Map<BookLoansVM>(bookDto);
    }

    public async Task<BookReviewsVM> GetBookReviews(int id)
    {
        var bookDto = await _client.BookReviewsAsync(id);
        return mapper.Map<BookReviewsVM>(bookDto);
    }

    public async Task<Response<int>> UpdateBook(UpdateBookVM book)
    {
        try
        {
            var bookDto = mapper.Map<UpdateBookDto>(book);
            var response = await _client.BookPUTAsync(bookDto.Id, bookDto);
            return new Response<int>() 
                { Successs = response.Success, Data = bookDto.Id, Message = response.Message, ValidationErrors = FlattErrors(response.Errors)};
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> ReplaceBook(int id, int? shelfId)
    {
        try
        {
            var response = await _client.ReplaceBookAsync(id, shelfId);
            return new Response<int>() { Successs = response.Success, Data = id, Message = response.Message, ValidationErrors = FlattErrors(response.Errors)};
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateBook(CreateBookVM book)
    {
        try
        {
            var response = new Response<int>();
            var createBookDto = mapper.Map<CreateBookDto>(book);
            var apiResponse = await _client.BookPOSTAsync(createBookDto);

            if (apiResponse.Success)
            {
                response.Data = apiResponse.Id;
                response.Successs = apiResponse.Success;
                response.Message = apiResponse.Message;
            }
            else
            {
                response.ValidationErrors = FlattErrors(apiResponse.Errors);
            }

            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> DeleteBook(int id)
    {
        try
        {
            await _client.BookDELETEAsync(id);
            return new Response<int>() { Successs = true, Message = "Deleted successfully" };
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }

    public async Task<List<BookListVM>> GetTopBooks(int limit)
    {
        var bookDtos = await _client.Top2Async(limit);
        return mapper.Map<List<BookListVM>>(bookDtos);
    }

    public async Task<BookVM?> GetBookByIsbn(string isbn)
    {
        var bookDto = await _client.IsbnAsync(isbn);
        return mapper.Map<BookVM>(bookDto);
    }

    public async Task<List<BookListVM>> GetBooksByCategory(string category)
    {
        var bookDtos = await _client.CategoryAsync(category);
        return mapper.Map<List<BookListVM>>(bookDtos);
    }

    public async Task<List<BookListVM>> GetBooksByGenre(string genre)
    {
        var bookDtos = await _client.GenreAsync(genre);
        return mapper.Map<List<BookListVM>>(bookDtos);
    }

    public async Task<List<BookListVM>> GetBooksByLanguage(string language)
    {
        var bookDtos = await _client.LanguageAsync(language);
        return mapper.Map<List<BookListVM>>(bookDtos);
    }

    public async Task<List<BookListVM>> GetBooksByPublicationDate(DateTime publicationDate)
    {
        var bookDtos = await _client.PublicationDateAsync(publicationDate);
        return mapper.Map<List<BookListVM>>(bookDtos);
    }
}
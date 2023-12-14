using Library.MVC.Models.Book;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IBookService
{
    Task<List<BookListVM>> GetBooks();
    Task<List<BookVM>> GetBooksForManagement();
    Task<BookVM> GetBook(int id);
    Task<List<BookListVM>> GetBooksByTitle(string title);
    Task<BookDetailedVM> GetBookDetailed(int id);
    Task<BookLoansVM> GetBookLoans(int id);
    Task<BookReviewsVM> GetBookReviews(int id);
    Task<Response<int>> UpdateBook(UpdateBookVM book);
    Task<Response<int>> ReplaceBook(int id, int? shelfId);
    Task<Response<int>> CreateBook(CreateBookVM book);
    Task<Response<int>> DeleteBook(int id);
    Task<List<BookListVM>> GetTopBooks(int i);
    Task<BookVM?> GetBookByIsbn(string isbn);
    Task<List<BookListVM>> GetBooksByCategory(string category);
    Task<List<BookListVM>> GetBooksByGenre(string genre);
    Task<List<BookListVM>> GetBooksByLanguage(string language);
    Task<List<BookListVM>> GetBooksByPublicationDate(DateTime publicationDate);
}
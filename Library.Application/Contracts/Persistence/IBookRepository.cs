using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Contracts.Persistence;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<Book?> GetBookWithDetailsAsync(int id);
    Task<List<Book>?> GetBookByTitleWithDetailsAsync(string title);
    
    Task<Book?> GetBookWithAuthorsAsync(int id);

    Task<List<Book>> GetBooksByIds(IEnumerable<int> ids);
    Task<IReadOnlyList<Book>?> GetBooksWithDetailsAsync();
    Task<IReadOnlyList<Book>?> GetTopBooksWithDetailsAsync(int limit);
    Task<Book?> GetBookWithReviewsAsync(int id);
    Task<Book?> GetBookWithLoansAsync(int id);

    Task<bool> ExistsAsync(string isbn);
    Task<Book?> GetAsync(string isbn);

    Task DecreaseCopiesAvailable(int bookId, int reservationAmount);
    Task IncreaseCopiesAvailable(int bookId, int reservationAmount);
    Task<Book?> GetBookByIsbnWithDetailsAsync(string isbn);
    Task<IReadOnlyList<Book>?> GetBookByCategoryDetailsAsync(string category);
    Task<IReadOnlyList<Book>?> GetBookByLanguageDetailsAsync(string language);
    Task<IReadOnlyList<Book>?> GetBookByGenreDetailsAsync(string genre);
    Task<IReadOnlyList<Book>?> GetBookByPublicationDateDetailsAsync(DateTime publicationDate);
}
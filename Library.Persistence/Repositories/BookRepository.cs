using System.Globalization;
using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class BookRepository(LibraryDbContext _dbContext) : GenericRepository<Book>(_dbContext), IBookRepository
{
    
    
    public async Task<Book?> GetBookWithDetailsAsync(int id)
    {
        return await _dbContext.Books
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(shelf => shelf.Shelf)
            .Include(pub => pub.Publisher)
            .Include(x => x.Reviews)!
            .ThenInclude(x => x.Customer)
            .Where(book => book.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Book>?> GetBookByTitleWithDetailsAsync(string titled)
    {
        var books = await _dbContext.Books
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(shelf => shelf.Shelf)
            .Include(pub => pub.Publisher)
            .Include(x => x.Reviews)!
            .ThenInclude(x => x.Customer)
            .Where(book => book.Title.ToLower() == titled.ToLower())
            .ToListAsync();

        return books;
    }

    public async Task<Book?> GetBookWithAuthorsAsync(int id)
    {
        return await _dbContext.Books.AsNoTracking().Include(bookAuthors => bookAuthors.Authors)
            .FirstOrDefaultAsync(book => book.Id == id);
    }

    public async Task<List<Book>> GetBooksByIds(IEnumerable<int> ids)
    {
        return await _dbContext.Books.Where(b => ids.Contains(b.Id)).ToListAsync();
    }

    public async Task<IReadOnlyList<Book>?> GetBooksWithDetailsAsync()
    {
        return await _dbContext.Books.Include(bookAuthors => bookAuthors.Authors)
            .Include(pub => pub.Publisher)
            .Include(x => x.Shelf)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Book>?> GetTopBooksWithDetailsAsync(int limit)
    {
        return await _dbContext.Books
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(pub => pub.Publisher)
            .Where(x => x.AvgRating >= 7)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<Book?> GetBookWithReviewsAsync(int id)
    {
        return await _dbContext.Books.Include(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Book?> GetBookWithLoansAsync(int id)
    {
        return await _dbContext.Books.Include(x => x.Loans)
            .ThenInclude(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<bool> ExistsAsync(string isbn)
    {
        return await GetAsync(isbn) != null;
    }

    public async Task<Book?> GetAsync(string isbn)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(x => x.Isbn.Equals(isbn));
    }

    public async Task DecreaseCopiesAvailable(int bookId, int reservationAmount)
    {
        var book = await _dbContext.Books.FindAsync(bookId);
        if (book == null)
            throw new NotFoundException(nameof(Book), bookId);
        book.CopiesAvailable -= reservationAmount;
    }

    public async Task IncreaseCopiesAvailable(int bookId, int reservationAmount)
    {
        var book = await _dbContext.Books.FindAsync(bookId);
        if (book == null)
            throw new NotFoundException(nameof(Book), bookId);
        book.CopiesAvailable += reservationAmount;
    }
    

    public async Task<Book?> GetBookByIsbnWithDetailsAsync(string isbn)
    {
        var book = await _dbContext.Books
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(shelf => shelf.Shelf)
            .Include(pub => pub.Publisher)
            .Include(x => x.Reviews)!
            .ThenInclude(x => x.Customer)
            .Where(book => book.Isbn.ToLower() == isbn.ToLower())
            .FirstOrDefaultAsync();

        return book;
    }

    public async Task<IReadOnlyList<Book>?> GetBookByCategoryDetailsAsync(string category)
    {
        var books = await _dbContext.Books
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(shelf => shelf.Shelf)
            .Include(pub => pub.Publisher)
            .Include(x => x.Reviews)!
            .ThenInclude(x => x.Customer)
            .Where(book => book.Categorie.ToLower() == category.ToLower())
            .ToListAsync();

        return books;
    }

    public async Task<IReadOnlyList<Book>?> GetBookByLanguageDetailsAsync(string language)
    {
        var books = await _dbContext.Books
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(shelf => shelf.Shelf)
            .Include(pub => pub.Publisher)
            .Include(x => x.Reviews)!
            .ThenInclude(x => x.Customer)
            .Where(book => book.Language.ToLower() == language.ToLower())
            .ToListAsync();

        return books;
    }

    public async Task<IReadOnlyList<Book>?> GetBookByGenreDetailsAsync(string genre)
    {
        var normalizedGenres = string.Join(", ", genre.Split(',')
            .Select(g => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(g.Trim().ToLower()))
            .ToArray());


        var books = await _dbContext.GetBooksByGenre(normalizedGenres)
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(shelf => shelf.Shelf)
            .Include(pub => pub.Publisher)
            .Include(x => x.Reviews)!
            .ThenInclude(x => x.Customer)
            .ToListAsync();

        return books;
    }

    public async Task<IReadOnlyList<Book>?> GetBookByPublicationDateDetailsAsync(DateTime publicationDate)
    {
        var books = await _dbContext.Books
            .Include(bookAuthors => bookAuthors.Authors)
            .Include(shelf => shelf.Shelf)
            .Include(pub => pub.Publisher)
            .Include(x => x.Reviews)!
            .ThenInclude(x => x.Customer)
            .Where(book => book.PublicationDate.Year == publicationDate.Year &&
                           book.PublicationDate.Month == publicationDate.Month &&
                           book.PublicationDate.Day == publicationDate.Day)
            .ToListAsync();

        return books;
    }
}
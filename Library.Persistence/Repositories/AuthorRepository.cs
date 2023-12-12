using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class AuthorRepository(LibraryDbContext _dbContext) : GenericRepository<Author>(_dbContext), IAuthorRepository
{
    public async Task<Author?> GetAuthorWithDetailsAsync(int id)
    {
        return await _dbContext.Authors.Include(x => x.Books)
            .FirstOrDefaultAsync(author => author.Id == id);
    }

    public async Task<List<Author>?> GetAuthorWithDetailsAsync(string name)
    {
        return await _dbContext.GetAuthorsByName(name)
            .Include(x => x.Books)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Author>?> GetAuthorsWithDetailsAsync()
    {
        return await _dbContext.Authors.Include(x => x.Books)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Author>?> GetTopAuthorsWithDetailsAsync(int limit)
    {
        return await _dbContext.Authors
            .Include(x => x.Books)
            //TODO CHANGE TO X.BOOKS>COUNT > 5
            .Where(x => x.Books.Count > 3)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<Author?> GetByFullName(string fName, string lName, string mName)
    {
        return await _dbContext.Authors
            .FirstOrDefaultAsync(x => x.FName.Equals(fName)
                                      && x.LName.Equals(lName) && x.MName.Equals(mName));
    }

    public async Task<IReadOnlyList<Author>?> GetAuthorByBirthdayDetailsAsync(DateTime date)
    {
        return await _dbContext.Authors.Include(x => x.Books)
            .Where(author => author.BirthDay != null &&
                             author.BirthDay.Value.Year == date.Year &&
                             author.BirthDay.Value.Month == date.Month &&
                             author.BirthDay.Value.Day == date.Day)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Author>?> GetAuthorByNationalityDetailsAsync(string nationality)
    {
        return await _dbContext.Authors.Include(x => x.Books)
            .Where(author => author.Nationality == nationality)
            .ToListAsync();
    }
}
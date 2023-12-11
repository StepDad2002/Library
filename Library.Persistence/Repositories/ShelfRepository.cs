using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class ShelfRepository(LibraryDbContext _dbContext) : GenericRepository<Shelf>(_dbContext), IShelfRepository
{
    public async Task<Shelf?> GetShelfWithDetailsAsync(int id)
    {
        return await _dbContext.Shelves
            .Where(x => x.Id == id)
            .Include(x => x.Books)
            .FirstOrDefaultAsync();

    }
    
    public async Task<List<Shelf>?> GetShelfWithDetailsAsync(string name)
    {
        return await _dbContext.Shelves
            .Include(x => x.Books)
            .Where(x => x.Name.ToLower()  == name.ToLower() )
            .ToListAsync();

    }

    public async Task<IReadOnlyList<Shelf>?> GetShelfsWithDetailsAsync()
    {
        return await _dbContext.Shelves.Include(x => x.Books)
            .ToListAsync();
    }
}
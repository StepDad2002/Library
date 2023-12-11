using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class GenericRepository<T>(LibraryDbContext _dbContext) : IGenericRepository<T>
    where T : class
{
    public async Task<T?> GetAsync(int id)
    {
        var entry = await _dbContext.Set<T>().FindAsync(id);
        if (entry == null)
        {
            throw new NotFoundException(typeof(T).Name, id);
        }

        return entry;
    }

    public virtual async Task<T?> GetAsyncNoTracking(int id)
    {
        var entry = await _dbContext.Set<T>().FindAsync(id);
        if (entry == null)
        {
            throw new NotFoundException(typeof(T).Name, id);
        }
        _dbContext.Entry(entry).State = EntityState.Detached;
        return entry;
    }

    public async Task<IReadOnlyList<T>?> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<IReadOnlyList<T>?> GetAllAsyncNoTracking()
    {
        var entryList = await _dbContext.Set<T>().ToListAsync();
        return entryList;
    }

    public async Task<T> AddAsync(T item)
    {
        await _dbContext.AddAsync(item);
        return item;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await GetAsyncNoTracking(id) is not null;
    }

    public async Task UpdateAsync(T item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
    }

    public async Task DeleteAsync(T item)
    {
        _dbContext.Set<T>().Remove(item);
    }
    
}
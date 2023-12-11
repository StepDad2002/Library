namespace Library.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(int id);
    Task<T?> GetAsyncNoTracking(int id);
    Task<IReadOnlyList<T>?> GetAllAsync();
    
    Task<IReadOnlyList<T>?> GetAllAsyncNoTracking();
    Task<T> AddAsync(T item);
    Task<bool> ExistsAsync(int id);
    
    Task UpdateAsync(T item);
    Task DeleteAsync(T item);
}
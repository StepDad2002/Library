using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Contracts.Persistence;

public interface IShelfRepository : IGenericRepository<Shelf>
{
    Task<Shelf?> GetShelfWithDetailsAsync(int id);
    Task<List<Shelf>?> GetShelfWithDetailsAsync(string name);
    Task<IReadOnlyList<Shelf>?> GetShelfsWithDetailsAsync();
}
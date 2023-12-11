using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Contracts.Persistence;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author?> GetAuthorWithDetailsAsync(int id);
    Task<List<Author?>> GetAuthorWithDetailsAsync(string name);
    Task<IReadOnlyList<Author>?> GetAuthorsWithDetailsAsync();
    Task<IReadOnlyList<Author>?> GetTopAuthorsWithDetailsAsync(int limit);
    Task<Author?> GetByFullName(string fName, string lName, string mName);
    Task<IReadOnlyList<Author>?> GetAuthorByBirthdayDetailsAsync(DateTime date);
    Task<IReadOnlyList<Author>?> GetAuthorByNationalityDetailsAsync(string nationality);
}
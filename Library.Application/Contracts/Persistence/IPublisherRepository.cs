using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Contracts.Persistence;

public interface IPublisherRepository : IGenericRepository<Publisher>
{
    Task<Publisher?> GetPublisherWithDetailsAsync(int id);
    Task<Publisher?> GetPublisherWithDetailsAsync(string name);
    Task<IReadOnlyList<Publisher>?> GetPublishersWithDetailsAsync();
    Task<bool> ExistsPhoneAsync(string phone);
    Task<bool> ExistsWebsiteAsync(string website);
    Task<Publisher?> GetByPhoneAsync(string phone);
    Task<Publisher?> GetByPhoneAsyncNoTracking(string phone);
    Task<Publisher?> GetByWebSiteAsyncNoTracking(string website);
    Task<object> GetTopPublishersWithDetailsAsync(int requestLimit);
}
using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class PublisherRepository(LibraryDbContext _dbContext) : GenericRepository<Publisher>(_dbContext), IPublisherRepository
{
    public async Task<Publisher?> GetPublisherWithDetailsAsync(int id)
    {
        return await _dbContext.Publishers
            .Include(x => x.Books)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Publisher?> GetPublisherWithDetailsAsync(string name)
    {
        return await _dbContext.Publishers
            .Include(x => x.Books)
            .Where(x => x.Name.ToLower()  == name.ToLower() )
            .FirstOrDefaultAsync();
    }


    public async Task<IReadOnlyList<Publisher>?> GetPublishersWithDetailsAsync()
    {
        return await _dbContext.Publishers.Include(x => x.Books)
            .ThenInclude(a => a.Authors)
            .ToListAsync();
    }
    

    public async Task<bool> ExistsPhoneAsync(string phone)
    {
        var publisherPhone = await _dbContext.Publishers.AsNoTracking().FirstOrDefaultAsync(x => x.Phone.Equals(phone));
        return publisherPhone is not null;
    }

    public async Task<bool> ExistsWebsiteAsync(string website)
    {
        var publisherPhone = await _dbContext.Publishers.AsNoTracking().FirstOrDefaultAsync(x => x.WebSite != null && x.WebSite.Equals(website));
        return publisherPhone is not null;
    }

    public async Task<Publisher?> GetByPhoneAsync(string phone)
    {
        return await _dbContext.Publishers
            .FirstOrDefaultAsync(x => x.Phone.Equals(phone));
    }

    public async Task<Publisher?> GetByPhoneAsyncNoTracking(string phone)
    {
        return await _dbContext.Publishers.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Phone.Equals(phone));
    }
    
    public async Task<Publisher?> GetByWebSiteAsyncNoTracking(string website)
    {
        return await _dbContext.Publishers.AsNoTracking()
            .FirstOrDefaultAsync(x => x.WebSite != null && x.WebSite.Equals(website));
    }

    public async Task<object> GetTopPublishersWithDetailsAsync(int requestLimit)
    {
        return await _dbContext.Publishers.Include(x => x.Books)
            .ThenInclude(a => a.Authors)
            //TODO Change x.Books.Count > 5
            .Where(x => x.Books.Count > 1)
            .Take(requestLimit)
            .ToListAsync();
    }
}
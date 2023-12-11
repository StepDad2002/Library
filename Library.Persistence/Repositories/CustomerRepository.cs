using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class CustomerRepository(LibraryDbContext _dbContext) : GenericRepository<Customer>(_dbContext), ICustomerRepository
{

    public async Task<Customer?> GetCustomerFinePaymentsAsync(int id)
    {
        return await _dbContext.Customers
            .Include(x => x.FinePayments)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetCustomerReservationsAsync(int id)
    {
        return await _dbContext.Customers
            .Include(x => x.Reservations!)
            .ThenInclude(b => b.Book)
            .ThenInclude(a => a.Authors)
            .Include(g => g.Reservations)!
            .ThenInclude(b => b.Book)
            .ThenInclude(p => p.Publisher)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetCustomerReviewsAsync(int id)
    {
        return await _dbContext.Customers
            .Include(x => x.Reviews)
            .ThenInclude(r => r.Book)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetCustomerLoansAsync(int id)
    {
        return await _dbContext.Customers
            .Include(x => x.Loans!)
            .ThenInclude(b => b.Book)
            .ThenInclude(a => a.Authors)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> TryLogInAsync(string email, string password)
    {
        var customer = await _dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));

        if (customer is null)
            return -1;
        return customer.Id;
    }

    public async Task<bool> ExistEmailAsync(string email)
    {
        var custEmail = await _dbContext.Customers
            .AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email));

        return custEmail != null;
    }

    public async Task<bool> ExistPasswordAsync(string password)
    {
        var custPassword = await _dbContext.Customers
            .AsNoTracking().FirstOrDefaultAsync(x => x.Password.Equals(password));

        return custPassword != null;
    }


    public async Task<Customer?> GetAsync(int id)
    {
        return await _dbContext.Customers
            .Include(x => x.Reservations)
            .Include(x => x.FinePayments)
            .Include(x => x.Loans)
            .Include(x => x.Reviews)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }
    
}
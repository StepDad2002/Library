using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class StaffRepository(LibraryDbContext _dbContext) : GenericRepository<Staff>(_dbContext), IStaffRepository
{
    public async Task<bool> ExistsEmailAsync(string email)
    {
        var staffEmail = await _dbContext.Staffs.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email));
        return staffEmail is not null;
    }

    public async Task<bool> ExistsPhoneAsync(string phone)
    {
        var staffPhone = await _dbContext.Staffs.AsNoTracking().FirstOrDefaultAsync(x => x.Phone.Equals(phone));
        return staffPhone is not null;
    }

    public async Task<Staff?> GetByEmailAsync(string email)
    {
        return await _dbContext.Staffs.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<Staff?> GetByPhoneAsync(string phone)
    {
        return await _dbContext.Staffs.FirstOrDefaultAsync(x => x.Phone.Equals(phone));
    }

    public async Task<int> TryLogInAsync(string email, string password)
    {
        var customer = await _dbContext.Staffs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));

        if (customer is null)
            return -1;
        return customer.Id;
    }

    public async Task<bool> ExistPasswordAsync(string password)
    {
        var staffPassword = await _dbContext.Staffs.AsNoTracking().FirstOrDefaultAsync(x => x.Password.Equals(password));
        return staffPassword is not null;
    }
}
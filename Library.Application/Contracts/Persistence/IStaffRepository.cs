using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface IStaffRepository : IGenericRepository<Staff>
{
    Task<bool> ExistsEmailAsync(string email);
    Task<bool> ExistsPhoneAsync(string phone);
    
    Task<Staff?> GetByEmailAsync(string email);
    Task<Staff?> GetByPhoneAsync(string phone);

    Task<int> TryLogInAsync(string email, string password);
    
    Task<bool> ExistPasswordAsync(string password);
}
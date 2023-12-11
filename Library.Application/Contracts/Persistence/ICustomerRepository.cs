using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer?> GetCustomerFinePaymentsAsync(int id);
    Task<Customer?> GetCustomerReservationsAsync(int id);
    Task<Customer?> GetCustomerReviewsAsync(int id);
    Task<Customer?> GetCustomerLoansAsync(int id);
    
    Task<int> TryLogInAsync(string email, string password);

    Task<bool> ExistEmailAsync(string email);
    Task<bool> ExistPasswordAsync(string password);
}
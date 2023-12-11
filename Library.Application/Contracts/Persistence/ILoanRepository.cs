using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface ILoanRepository : IGenericRepository<Loan>
{
    Task<Loan?> GetLoanWithDetailsAsync(int id);
    Task<IReadOnlyList<Loan>?> GetLoansWithDetailsAsync();
}
using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class LoanRepository(LibraryDbContext _dbContext) : GenericRepository<Loan>(_dbContext), ILoanRepository
{
    public async Task<Loan?> GetLoanWithDetailsAsync(int id)
    {
        return await _dbContext.Loans
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<Loan>?> GetLoansWithDetailsAsync()
    {
        return await _dbContext.Loans
            .Include(x => x.Book)
            .ThenInclude(b => b.Authors)
            .Include(x => x.Customer)
            .ToListAsync();
    }
}
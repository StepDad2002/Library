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

    public async Task<IReadOnlyList<Loan>?> GetLoansByLoanDateAsync(DateTime loanDate)
    {
        return await _dbContext.Loans
            .Include(x => x.Book)
            .ThenInclude(b => b.Authors)
            .Include(x => x.Customer)
            .Where(x => x.LoanDate.Year == loanDate.Year &&
                        x.LoanDate.Month == loanDate.Month &&
                        x.LoanDate.Day == loanDate.Day)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Loan>?> GetLoansByDueDateAsync(DateTime dueDate)
    {
        return await _dbContext.Loans
            .Include(x => x.Book)
            .ThenInclude(b => b.Authors)
            .Include(x => x.Customer)
            .Where(x => x.DueDate.Year == dueDate.Year &&
                        x.DueDate.Month == dueDate.Month &&
                        x.DueDate.Day == dueDate.Day)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Loan>?> GetLoansByReturnedDateAsync(DateTime returnedDate)
    {
        return await _dbContext.Loans
            .Include(x => x.Book)
            .ThenInclude(b => b.Authors)
            .Include(x => x.Customer)
            .Where(x => x.ReturnedDate.Year == returnedDate.Year &&
                        x.ReturnedDate.Month == returnedDate.Month &&
                        x.ReturnedDate.Day == returnedDate.Day)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Loan>?> GetLoansByBookTitleAsync(string title)
    {
        return await _dbContext.Loans
            .Include(x => x.Book)
            .ThenInclude(b => b.Authors)
            .Include(x => x.Customer)
            .Where(x => x.Book.Title == title)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Loan>?> GetLoansByCustomerPhoneAsync(string phone)
    {
        return await _dbContext.Loans
            .Include(x => x.Book)
            .ThenInclude(b => b.Authors)
            .Include(x => x.Customer)
            .Where(x => x.Customer.Phone == phone)
            .ToListAsync();
    }
}
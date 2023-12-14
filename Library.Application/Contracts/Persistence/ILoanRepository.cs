using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface ILoanRepository : IGenericRepository<Loan>
{
    Task<Loan?> GetLoanWithDetailsAsync(int id);
    Task<IReadOnlyList<Loan>?> GetLoansWithDetailsAsync();
    Task<IReadOnlyList<Loan>?> GetLoansByLoanDateAsync(DateTime loanDate);
    Task<IReadOnlyList<Loan>?> GetLoansByDueDateAsync(DateTime dueDate);
    Task<IReadOnlyList<Loan>?> GetLoansByReturnedDateAsync(DateTime returnedDate);
    Task<IReadOnlyList<Loan>?> GetLoansByBookTitleAsync(string title);
    Task<IReadOnlyList<Loan>?> GetLoansByCustomerPhoneAsync(string phone);
}
using Library.MVC.Models.Loan;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface ILoanService
{
    Task<List<LoanListVM>> GetLoans();
    Task<List<LoanListVM>> GetLoansByLoanDate(DateTime date);
    Task<List<LoanListVM>> GetLoansByReturnedDate(DateTime date);
    Task<List<LoanListVM>> GetLoansByDueDate(DateTime date);
    Task<List<LoanListVM>> GetLoansByBookTitle(string title);
    Task<List<LoanListVM>> GetLoansByCustomerPhone(string phone);
    Task<LoanVM> GetLoan(int id);
    Task<Response<int>> UpdateLoan(UpdateLoanVM loan);
    Task<Response<int>> CreateLoan(CreateLoanVM loan);
    Task<Response<int>> DeleteLoan(int id);
}
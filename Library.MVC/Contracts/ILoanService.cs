using Library.MVC.Models.Loan;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface ILoanService
{
    Task<List<LoanListVM>> GetLoans();
    Task<LoanVM> GetLoan(int id);
    Task<Response<int>> UpdateLoan(UpdateLoanVM loan);
    Task<Response<int>> CreateLoan(CreateLoanVM loan);
    Task<Response<int>> DeleteLoan(int id);
}
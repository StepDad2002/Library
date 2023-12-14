using Library.MVC.Models;
using Library.MVC.Models.Customer;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface ICustomerService
{
    Task<List<CustomerListVM>> GetCustomers();
    Task<CustomerVm?> GetCustomer(int id);
    Task<CustomerListVM?> GetCustomerByEmail(string email);
    Task<CustomerListVM?> GetCustomerByPhone(string phone);
    Task<CustomerLoansVM> GetCustomerLoans(int id);
    Task<CustomerFinePaymentsVM> GetCustomerFinePayments(int id);
    Task<CustomerReservationsVM> GetCustomerReservations(int id);
    Task<CustomerReviewsVM> GetCustomerReviews(int id);
    Task<Response<int>> UpdateCustomer(UpdateCustomerVM customer);
    Task<Response<int>> CreateCustomer(CreateCustomerVM customer);
    Task<Response<int>> DeleteCustomer(int id);

    Task<Response<int>> LogIn(LoginVM login);
}
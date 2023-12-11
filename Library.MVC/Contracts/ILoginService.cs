using Library.MVC.Models;

namespace Library.MVC.Contracts;

public interface ILoginService
{
    Task<bool> LogInCustomer(LoginVM login);
    Task<bool> LogInStaff(LoginVM login);
    Task LogOut();
}
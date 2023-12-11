using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class LoginService(ILocalStorageService localStorage, IClient client, IMapper mapper, ICustomerService customerService,
    IStaffService staffService) : 
    BaseHttpService(localStorage, client), ILoginService
{
    public async Task<bool> LogInCustomer(LoginVM login)
    {
        var response = await customerService.LogIn(login);

        if (response.Successs)
        {
            localStorage.SetStorageValue("UserID", response.Data);
        }
        
        return response.Successs;
    }

    public async Task<bool> LogInStaff(LoginVM login)
    {
        var response = await staffService.LogIn(login);
        if (response.Successs)
        {
            localStorage.SetStorageValue("UserID", response.Data);
        }
        return response.Successs;
    }

    public async Task LogOut()
    {
        localStorage.ClearStorage(new List<string>() {"UserID"});
    }
}
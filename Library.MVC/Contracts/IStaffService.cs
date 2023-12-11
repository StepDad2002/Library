using Library.MVC.Models;
using Library.MVC.Models.Staff;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IStaffService
{
    Task<List<StaffListVM>> GetStaffs();
    Task<StaffVM> GetStaff(int id);
    Task<Response<int>> UpdateStaff(UpdateStaffVM staff);
    Task<Response<int>> CreateStaff(CreateStaffVM staff);
    Task<Response<int>> DeleteStaff(int id);

    Task<Response<int>> LogIn(LoginVM login);
}
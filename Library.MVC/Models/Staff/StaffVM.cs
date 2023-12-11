namespace Library.MVC.Models.Staff;

public class StaffVM : UpdateStaffVM
{
    public DateTime HireDate { get => DateTime.Now; }
}
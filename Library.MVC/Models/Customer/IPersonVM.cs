using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Customer;

public interface IPersonVM
{

    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
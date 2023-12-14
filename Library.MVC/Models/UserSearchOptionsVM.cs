using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models;

public class UserSearchOptionsVM
{
    [RegularExpression(@"^\d{3}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Input does not match a pattern XXX-XXX-XX-XX")]
    public string Phone { get; set; }
    
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Input does not match a pattern example@mail.com")]
    public string Email { get; set; }
}
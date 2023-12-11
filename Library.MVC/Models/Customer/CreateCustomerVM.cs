using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Customer;

public class CreateCustomerVM : IPersonVM
{
    [Required, Display(Name = "First Name"),
     StringLength(25, MinimumLength = 2, ErrorMessage = "{0} must have at least 2 characters"),
     RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use only letters in first name")]
    public string FName { get; set; }

    [Required, Display(Name = "Last Name"),
     StringLength(25, MinimumLength = 2, ErrorMessage = "{0} must have at least 2 characters"),
     RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use only letters in last name")]
    public string LName { get; set; }

    [Required, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; }

    [Required, RegularExpression(@"^\d{3}-\d{3}-\d{2}-\d{2}$")]
    public string Phone { get; set; }

    [Required] public string Password { get; set; }
}
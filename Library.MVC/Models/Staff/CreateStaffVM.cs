using System.ComponentModel.DataAnnotations;
using Library.Domain.Enums;
using Library.MVC.CustomValidationAttrs;
using Library.MVC.Models.Customer;

namespace Library.MVC.Models.Staff;

public class CreateStaffVM : IPersonVM
{
    [Required, Display(Name = "First Name"),
     StringLength(25, MinimumLength = 2, ErrorMessage = "{0} must have at least 2 characters"),
     RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use only letters in first name")]
    public string FName { get; set; }
    
    [Required, Display(Name = "Last Name"),
     StringLength(25, MinimumLength = 2, ErrorMessage = "{0} must have at least 2 characters"),
     RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use only letters in last name")]
    public string LName { get; set; }
    
    [Required, RegularExpression(@"^\d{3}-\d{3}-\d{2}-\d{2}$")]
    public string Phone { get; set; }
    
    [Required, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; }
    [IsEnumName(typeof(Position)),Required]
    public string Position { get; set; }
    [Required,Range(250,Double.MaxValue, MinimumIsExclusive = false)]
    public decimal Salary { get; set; }
    public DateTime HireDate { get => DateTime.Now; }

    [Required]
    public string Password { get; set; }
}
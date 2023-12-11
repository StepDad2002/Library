using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Author;

public class CreateAuthorVM
{
    [Required, Display(Name = "First Name"),
     StringLength(25, MinimumLength = 2, ErrorMessage = "{0} must have at least 2 characters"),
     RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use only letters in first name")]
    public string FName { get; set; }

    [Required, Display(Name = "Middle Name"),
     StringLength(25, MinimumLength = 2, ErrorMessage = "{0} must have at least 2 characters"),
     RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use only letters in middle name")]
    public string MName { get; set; }

    [Required, Display(Name = "Last Name"),
     StringLength(25, MinimumLength = 2, ErrorMessage = "{0} must have at least 2 characters"),
     RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use only letters in last name")]
    public string LName { get; set; }
}

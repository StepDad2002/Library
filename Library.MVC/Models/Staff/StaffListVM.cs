using System.ComponentModel.DataAnnotations;
using Library.Domain.Enums;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.Staff;

public class StaffListVM : StaffVM
{
    public int Id { get; set; }
    [IsEnumName(typeof(Position)),Required]
    public string Position { get; set; }
    
    public string FName { get; set; }
    
    public string LName { get; set; }

    public string Phone { get; set; }
    
    public string Email { get; set; }

    public DateTime HireDate { get; set; }
}
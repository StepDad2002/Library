using Library.Application.DTOs.Common;

namespace Library.Application.DTOs;

public class StaffDto : BaseDto, IPersonDto
{
    public string Position { get; set; }

    public decimal Salary { get; set; }
    
    public string FName { get; set; }
    
    public string LName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Phone { get; set; }

    public DateTime HireDate { get; set; }
}
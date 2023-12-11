using Library.Application.DTOs.Common;

namespace Library.Application.DTOs;

public class StaffListDto : BaseDto
{
    public string Position { get; set; }
    
    public string FName { get; set; }
    
    public string LName { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    public DateTime HireDate { get; set; }
}
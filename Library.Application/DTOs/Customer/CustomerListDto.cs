using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Customer;

public class CustomerListDto : BaseDto, IPersonDto
{
    public string FName { get; set; }
    
    public string LName { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
}
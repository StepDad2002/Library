namespace Library.Application.DTOs.Common;

public interface IPersonDto
{
    public string FName { get; set; }
    
    public string LName { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
}
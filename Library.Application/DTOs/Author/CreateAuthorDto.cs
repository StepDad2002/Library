using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Author;

public class CreateAuthorDto : IAuthorDto
{
    public string FName { get; set; }
    
    public string MName { get; set; }
    
    public string LName { get; set; }
    
    
}
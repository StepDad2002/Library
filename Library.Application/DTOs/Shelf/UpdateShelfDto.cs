using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Shelf;

public class UpdateShelfDto : BaseDto, IShelfDto
{
    public string Name { get; set; }
    
    public string? Description { get; set; }
}
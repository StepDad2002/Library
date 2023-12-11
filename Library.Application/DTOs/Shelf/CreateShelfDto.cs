namespace Library.Application.DTOs.Shelf;

public class CreateShelfDto : IShelfDto
{
    public string Name { get; set; }

    public string? Description { get; set; }
}
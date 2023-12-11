using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Shelf;

public class CreateShelfVM
{
    [Required, MaxLength(60)]
    public string Name { get; set; }

    [MaxLength(150)]
    public string? Description { get; set; }

}

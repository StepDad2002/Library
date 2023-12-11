using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Publisher;

public class CreatePublisherVM
{
    [Required, MaxLength(75)]
    public string Name { get; set; }
    [Required, RegularExpression(@"^\d{3}-\d{3}-\d{2}-\d{2}$")]
    public string Phone { get; set; }
    [RegularExpression(@"^(http|https)://[a-zA-Z0-9-\.]+\.[a-zA-Z]{2,4}(/\S*)?$")]
    public string? WebSite { get; set; }
}
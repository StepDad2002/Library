using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Publisher;

public class CreatePublisherDto : IPublisherDto
{
    public string Name { get; set; }
    
    public string Phone { get; set; }
    
    public string? WebSite { get; set; }
}
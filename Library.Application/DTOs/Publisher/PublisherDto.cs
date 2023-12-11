using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Publisher;

public class PublisherDto : BaseDto, IPublisherDto
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public string? WebSite { get; set; }
    
    public virtual ICollection<BookDtoNoReferences> Books { get; set; }
}
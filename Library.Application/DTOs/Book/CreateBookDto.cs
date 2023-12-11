using Library.Application.DTOs.Author;
using Library.Application.DTOs.Common;
using Library.Application.DTOs.Publisher;

namespace Library.Application.DTOs.Book;

public class CreateBookDto : IBookDto
{
    public CreatePublisherDto Publisher { get; set; }
    
    public DateTime PublicationDate { get; set; }
    
    public string[] Genres { get; set; }
    
    public ICollection<CreateAuthorDto> Authors { get; set; }
    
    public string Title { get; set; }
    
    public string Isbn { get; set; }
    
    public string Categorie { get; set; }
    
    public string Language { get; set; }
    
    public int CopiesAvailable { get; set; }

    public int? ShelfId { get; set; }
    
}
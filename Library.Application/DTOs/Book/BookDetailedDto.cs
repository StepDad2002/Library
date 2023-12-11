using Library.Application.DTOs.Author;
using Library.Application.DTOs.Common;
using Library.Application.DTOs.Publisher;
using Library.Application.DTOs.Shelf;

namespace Library.Application.DTOs.Book;

public class BookDetailedDto : BaseDto, IBookDto
{
    public string Title { get; set; }
    
    public string Isbn { get; set; }
    
    public string[] Genres { get; set; }
    
    public string Categorie { get; set; }
    
    public string Language { get; set; }
    
    public PublisherDto Publisher { get; set; }
    
    public ICollection<AuthorDto> Authors { get; set; }
    
    public ShelfDto? Shelf { get; set; }
    
    public double? AvgRating { get; set; }
    
    public string? Description { get; set; }
    
    public int CopiesAvailable { get; set; }
    
    public DateTime PublicationDate { get; set; }
    
}
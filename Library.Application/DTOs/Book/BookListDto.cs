using System.Text;
using Library.Application.DTOs.Author;
using Library.Application.DTOs.Common;
using Library.Application.DTOs.Publisher;

namespace Library.Application.DTOs.Book;

public class BookListDto : BaseDto, IBookDto
{
    public UpdatePublisherDto Publisher { get; set; }
    
    public DateTime PublicationDate { get; set; }
    public string[] Genres { get; set; }
    
    public string Categorie { get; set; }

    public ICollection<AuthorDto> Authors { get; set; }

    public string Title { get; set; }
    public string Isbn { get; set; }
    
    public string Language { get; set; }

    public double? AvgRating { get; set; } = 0;
    
    public string? Description { get; set; }

}
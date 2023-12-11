using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Book;

public class UpdateBookDto : BaseDto, IBookDto
{
    public string Title { get; set; }
    
    public string Isbn { get; set; }

    public string Categorie { get; set; }
    
    public string Language { get; set; }
    
    public string[] Genres { get; set; }

    public string? Description { get; set; }

    public int CopiesAvailable { get; set; }
    
    public double? AvgRating { get; set; }
    
    public DateTime PublicationDate { get; set; }

}
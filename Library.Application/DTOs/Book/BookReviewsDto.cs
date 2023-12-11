using Library.Application.DTOs.Common;
using Library.Application.DTOs.Review;

namespace Library.Application.DTOs.Book;

public class BookReviewsDto : BaseDto, IBookDto
{
    public string Title { get; set; }

    public double? AvgRating { get; set; }

    public string Categorie { get; set; }

    public string Language { get; set; }
    
    public string[] Genres { get; set; }
    
    public ICollection<ReviewListDto>? Reviews { get; set; }
}
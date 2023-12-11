using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Review;

public class ReviewDtoNoCustomer : BaseDto, IReviewDto
{
    public int? Rating { get; set; }

    public string Comment { get; set; }
    
    public int BookId { get; set; }

    public BookDtoNoReferences Book { get; set; }
    
    public DateTime ReviewDate { get; set; }
}
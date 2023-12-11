using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;
using Library.Application.DTOs.Customer;

namespace Library.Application.DTOs.Review;

public class ReviewDto : BaseDto, IReviewDto
{
    public int? Rating { get; set; }

    public string Comment { get; set; }
    
    public int BookId { get; set; }

    public BookDtoNoReferences Book { get; set; }
    
    public int CustomerId { get; set; }

    public CustomerListDto Customer { get; set; }

    public DateTime ReviewDate { get; set; }
}
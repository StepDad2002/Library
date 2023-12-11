using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Review;

public class ReviewListDto : BaseDto
{
    public int? Rating { get; set; }

    public string Comment { get; set; }
    
    public int BookId { get; set; }

    public int CustomerId { get; set; }

    public DateTime ReviewDate { get; set; }
}
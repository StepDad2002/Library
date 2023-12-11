namespace Library.Application.DTOs.Review;

public class CreateReviewDto : IReviewDto
{
    public int? Rating { get; set; }

    public string Comment { get; set; }
    
    public int BookId { get; set; }
    
    public int CustomerId { get; set; }

    public DateTime ReviewDate { get => DateTime.Now; }
}
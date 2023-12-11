namespace Library.Application.DTOs.Review;

public interface IReviewDto
{
    int? Rating { get; set; }
    string Comment { get; set; }
    
}
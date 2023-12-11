using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Review;

public class CreateReviewVM
{
    public int? Rating { get; set; }
    [MaxLength(500)]
    public string Comment { get; set; }
    [Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int BookId { get; set; }
    [Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int CustomerId { get; set; }

    public DateTime ReviewDate { get => DateTime.Now; }
}
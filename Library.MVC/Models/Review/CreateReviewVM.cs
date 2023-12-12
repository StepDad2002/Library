using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Review;

public class CreateReviewVM
{
    [Range(1,10)]
    public int? Rating { get; set; }
    [Required, MaxLength(500)]
    public string Comment { get; set; }
    [Required, Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int BookId { get; set; }
    [Required, Range(0, int.MaxValue, MinimumIsExclusive = true)]
    public int CustomerId { get; set; }

    public DateTime ReviewDate { get => DateTime.Now; }
}
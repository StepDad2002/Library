using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Review;

public class UpdateReviewVM
{
    public int Id { get; set; }
    [Range(0,10, MaximumIsExclusive = false,MinimumIsExclusive = false)]
    public int? Rating { get; set; }
    [MaxLength(500)]
    public string Comment { get; set; }
}
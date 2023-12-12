using System.ComponentModel.DataAnnotations;

namespace Library.MVC.Models.Review;

public class UpdateReviewVM
{
    public int Id { get; set; }
    [Range(1,10)]
    public int? Rating { get; set; }
    [Required, MaxLength(500)]
    public string Comment { get; set; }
}
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Review;

public class UpdateReviewDto : BaseDto, IReviewDto
{
    public int? Rating { get; set; }

    public string Comment { get; set; }
}
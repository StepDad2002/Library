using Library.Application.DTOs.Common;
using Library.Application.DTOs.Review;

namespace Library.Application.DTOs.Customer;

public class CustomerReviewsDto : BaseDto
{
    public ICollection<ReviewDtoNoCustomer>? Reviews { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }
}
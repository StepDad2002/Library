using System.ComponentModel.DataAnnotations;
using Library.MVC.Models.Review;

namespace Library.MVC.Models.Customer;

public class CustomerReviewsVM
{
    [Range(0, Int32.MaxValue,MinimumIsExclusive = true)]
    public int Id { get; set; }
    
    public ICollection<ReviewNoCustomerVM>? Reviews { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }
}
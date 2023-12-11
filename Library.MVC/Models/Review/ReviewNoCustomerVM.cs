using Library.MVC.Models.Book;

namespace Library.MVC.Models.Review;

public class ReviewNoCustomerVM : CreateReviewVM
{
    public int Id { get; set; }
    public int BookId { get; set; }

    public BookNoReferencesVM Book { get; set; }
    
}
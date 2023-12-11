using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;
using Library.MVC.Models.Book;
using Library.MVC.Models.Customer;

namespace Library.MVC.Models.Review;

public class ReviewVM : UpdateReviewVM
{
    [DateNotInFuture, Range(typeof(DateTime), "1/1/1753", "31/12/9999")]
    public new DateTime ReviewDate { get; set; }
    
    public BookNoReferencesVM Book { get; set; }
    
    public CustomerListVM Customer { get; set; }
}
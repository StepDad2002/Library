using Library.MVC.Models.Review;

namespace Library.MVC.Models.Book;

public class BookReviewsVM
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public double? AvgRating { get; set; }

    public string Categorie { get; set; }

    public string Language { get; set; }
    
    public string[] Genres { get; set; }
    
    public ICollection<ReviewListVM>? Reviews { get; set; }
}
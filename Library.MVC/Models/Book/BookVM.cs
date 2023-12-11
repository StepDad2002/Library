using Library.MVC.Models.Author;
using Library.MVC.Models.Loan;
using Library.MVC.Models.Publisher;
using Library.MVC.Models.Review;
using Library.MVC.Models.Shelf;

namespace Library.MVC.Models.Book;

public class BookVM : UpdateBookVM
{
    public ICollection<LoanVM>? Loans { get; set; }

    public ICollection<ReviewVM>? Reviews { get; set; }

    public ShelfVM Shelf { get; set; }
    public int? ShelfId { get; set; }

    public new PublisherVM Publisher { get; set; }
    public new ICollection<AuthorVM> Authors { get; set; }
}
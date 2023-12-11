using Library.MVC.Models.Author;
using Library.MVC.Models.Book;
using Library.MVC.Models.Publisher;

namespace Library.MVC.Models;

public class BookAuthorPublisherWrapper
{
    public List<BookListVM> Books { get; set; }

    public List<PublisherListVM> Publishers { get; set; }
    
    public List<AuthorVM> Authors { get; set; }
}
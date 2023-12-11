using Library.MVC.Models.Book;

namespace Library.MVC.Models.Publisher;

public class PublisherVM : UpdatePublisherVM
{
    public virtual ICollection<BookNoReferencesVM> Books { get; set; }
}
using Library.MVC.Models.Book;

namespace Library.MVC.Models.Publisher;

public class PublisherListVM : CreatePublisherVM
{
    public int Id { get; set; }

    public virtual ICollection<BookNoReferencesVM> Books { get; set; }
}
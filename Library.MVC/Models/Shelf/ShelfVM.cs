using Library.MVC.Models.Book;

namespace Library.MVC.Models.Shelf;

public class ShelfVM : UpdateShelfVM
{
    public ICollection<BookNoReferencesVM> Books { get; set; }
}
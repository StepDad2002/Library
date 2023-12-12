using System.ComponentModel.DataAnnotations;
using Library.MVC.Models.Book;

namespace Library.MVC.Models.Author;

public class AuthorVM : UpdateAuthorVM
{
    public ICollection<BookNoReferencesVM> Books { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Library.MVC.Models.Book;

namespace Library.MVC.Models.Author;

public class AuthorVM : UpdateAuthorVM
{
    [MinLength(1)] public ICollection<BookNoReferencesVM> Books { get; set; }
}
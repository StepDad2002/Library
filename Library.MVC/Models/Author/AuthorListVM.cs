namespace Library.MVC.Models.Author;

public class AuthorListVM : CreateAuthorVM
{
    public int Id { get; set; }
    public DateTime? BirthDay { get; set; }
    
}
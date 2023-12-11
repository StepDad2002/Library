namespace Library.MVC.Models.Book;

public class BookSearchOptionsVM
{
    public string Category { get; set; }
    public string Language { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Isbn { get; set; }
    public DateTime? PublicationDate { get; set; }
}
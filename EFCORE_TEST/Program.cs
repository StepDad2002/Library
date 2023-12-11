using Library.Persistance;

Console.WriteLine("Hi there");

using (var db = new LibraryDbContext(@"Server=.\SQLEXPRESS;Database=Library_Development;Trusted_Connection=True;TrustServerCertificate=True"))
{
    var list = db.GetBooksByGenre("All Genres").ToList();

    foreach (var book in list)
    {
        Console.WriteLine(book.Title);
        Console.WriteLine(book.Publisher.Name);
    }
}
namespace EFCORE_TEST.Entities11;

public partial class Author
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string? Nationality { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Biography { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

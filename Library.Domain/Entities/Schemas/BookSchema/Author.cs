using Library.Domain.Common;

namespace Library.Domain.Entities.Schemas.BookSchema;

public class Author : BaseDomainEntity
{
    public string FName { get; set; } = null!;

    public string MName { get; set; } = null!;
    public string LName { get; set; } = null!;

    public string FullName => FName + " " + LName + " " + MName;

    public string? Nationality { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Biography { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}
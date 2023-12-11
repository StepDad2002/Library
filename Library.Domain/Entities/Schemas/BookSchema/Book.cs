using Library.Domain.Common;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Domain.Entities.Schemas.BookSchema;

public class Book : BaseDomainEntity
{
    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public string[] Genres { get; set; }

    public DateTime PublicationDate { get; set; }

    public string? Description { get; set; }

    public int PublisherId { get; set; }

    public int CopiesAvailable { get; set; }

    public double? AvgRating { get; set; }

    public int? ShelfId { get; set; }

    public virtual string Categorie { get; set; }

    public virtual string Language { get; set; }

    public virtual ICollection<Loan>? Loans { get; set; }

    public virtual Publisher Publisher { get; set; }

    public virtual ICollection<Review>? Reviews { get; set; }

    public virtual Shelf Shelf { get; set; }

    public virtual ICollection<Author> Authors { get; set; }
}
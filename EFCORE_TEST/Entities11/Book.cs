namespace EFCORE_TEST.Entities11;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Genres { get; set; }

    public DateTime? PublicationDate { get; set; }

    public string? Description { get; set; }

    public int? LanguageId { get; set; }

    public int PublisherId { get; set; }

    public int CopiesAvailable { get; set; }

    public double? AvgRating { get; set; }

    public int? ShelfId { get; set; }

    public int? ReservationId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Shelf? Shelf { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}

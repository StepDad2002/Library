using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("Books", Schema = "Book")]
[Index("CategoryId", Name = "IX_Books_CategoryId")]
[Index("Isbn", Name = "IX_Books_ISBN", IsUnique = true)]
[Index("LanguageId", Name = "IX_Books_LanguageId")]
[Index("PublisherId", Name = "IX_Books_PublisherId")]
[Index("ReservationId", Name = "IX_Books_ReservationId")]
[Index("ShelfId", Name = "IX_Books_ShelfId")]
public partial class Book
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    [Column("ISBN")]
    public string Isbn { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Genres { get; set; }

    public DateTime? PublicationDate { get; set; }

    [StringLength(300)]
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

    [ForeignKey("CategoryId")]
    [InverseProperty("Books")]
    public virtual Category? Category { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Books")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    [ForeignKey("PublisherId")]
    [InverseProperty("Books")]
    public virtual Publisher Publisher { get; set; } = null!;

    [ForeignKey("ReservationId")]
    [InverseProperty("Books")]
    public virtual Reservation? Reservation { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("ShelfId")]
    [InverseProperty("Books")]
    public virtual Shelf? Shelf { get; set; }

    [ForeignKey("BooksId")]
    [InverseProperty("Books")]
    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}

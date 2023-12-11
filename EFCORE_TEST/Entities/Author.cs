using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE_TEST.Entities;

[Table("Authors", Schema = "Book")]
public partial class Author
{
    [Key]
    public int Id { get; set; }

    [Column("FName")]
    [StringLength(25)]
    public string Fname { get; set; } = null!;

    [Column("LName")]
    [StringLength(25)]
    public string Lname { get; set; } = null!;

    public string? Nationality { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Biography { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [ForeignKey("AuthorsId")]
    [InverseProperty("Authors")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

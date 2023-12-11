using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE_TEST.Entities;

[Table("Shelves", Schema = "Book")]
public partial class Shelf
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [InverseProperty("Shelf")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

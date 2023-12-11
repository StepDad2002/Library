using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE_TEST.Entities;

[Table("Categorie", Schema = "Book")]
public partial class Category
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [InverseProperty("Categorie")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE_TEST.Entities;

[Table("Languages", Schema = "Book")]
public partial class Language
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [StringLength(10)]
    public string? Code { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [InverseProperty("Language")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

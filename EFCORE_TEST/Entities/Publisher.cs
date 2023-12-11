using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("Publishers", Schema = "Book")]
[Index("AddressId", Name = "IX_Publishers_AddressId")]
[Index("Phone", Name = "IX_Publishers_Phone", IsUnique = true)]
public partial class Publisher
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? AddressId { get; set; }

    public string Phone { get; set; } = null!;

    public string? WebSite { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Publishers")]
    public virtual Address? Address { get; set; }

    [InverseProperty("Publisher")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

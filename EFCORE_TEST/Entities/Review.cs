using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("Reviews", Schema = "Management")]
[Index("BookId", Name = "IX_Reviews_BookId")]
[Index("CustomerId", Name = "IX_Reviews_CustomerId")]
public partial class Review
{
    [Key]
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? Rating { get; set; }

    [StringLength(350)]
    public string Comment { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public int BookId { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Reviews")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Reviews")]
    public virtual Customer? Customer { get; set; }
}

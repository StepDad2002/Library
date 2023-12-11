using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("FinePayments", Schema = "Management")]
[Index("CustomerId", Name = "IX_FinePayments_CustomerId")]
public partial class FinePayment
{
    [Key]
    public int Id { get; set; }

    public int CustomerId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("FinePayments")]
    public virtual Customer Customer { get; set; } = null!;
}

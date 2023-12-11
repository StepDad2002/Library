using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("Loans", Schema = "Management")]
[Index("BookId", Name = "IX_Loans_BookId")]
[Index("CustomerId", Name = "IX_Loans_CustomerId")]
public partial class Loan
{
    [Key]
    public int Id { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime ReturnedDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal FineAmount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public int BookId { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Loans")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Loans")]
    public virtual Customer Customer { get; set; } = null!;
}

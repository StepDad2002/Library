using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("Reservations", Schema = "Management")]
[Index("CustomerId", Name = "IX_Reservations_CustomerId")]
public partial class Reservation
{
    [Key]
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [InverseProperty("Reservation")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Reservations")]
    public virtual Customer? Customer { get; set; }
}

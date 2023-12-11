using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("Staffs", Schema = "Management")]
[Index("AddressId", Name = "IX_Staffs_AddressId")]
[Index("Phone", Name = "IX_Staffs_Phone", IsUnique = true)]
public partial class Staff
{
    [Key]
    public int Id { get; set; }

    [Column("FName")]
    public string Fname { get; set; } = null!;

    [Column("LName")]
    public string Lname { get; set; } = null!;

    public string? Email { get; set; }

    [StringLength(15)]
    public string Phone { get; set; } = null!;

    public int? AddressId { get; set; }

    public string Position { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Salary { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Staff")]
    public virtual Address? Address { get; set; }
}

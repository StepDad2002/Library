using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Entities;

[Table("Customers", Schema = "Management")]
[Index("AddressId", Name = "IX_Customers_AddressId")]
[Index("Phone", Name = "IX_Customers_Phone", IsUnique = true)]
public partial class Customer
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

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Customers")]
    public virtual Address? Address { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<FinePayment> FinePayments { get; set; } = new List<FinePayment>();

    [InverseProperty("Customer")]
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    [InverseProperty("Customer")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [InverseProperty("Customer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

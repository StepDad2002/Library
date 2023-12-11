using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE_TEST.Entities;

[Table("Address")]
public partial class Address
{
    [Key]
    public int Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? Home { get; set; }

    public string? Zip { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Address")]
    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();

    [InverseProperty("Address")]
    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

namespace EFCORE_TEST.Entities11;

public partial class Address
{
    public int Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? Home { get; set; }

    public string? Zip { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

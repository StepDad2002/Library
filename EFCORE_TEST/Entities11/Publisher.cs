namespace EFCORE_TEST.Entities11;

public partial class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? AddressId { get; set; }

    public string Phone { get; set; } = null!;

    public string? WebSite { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

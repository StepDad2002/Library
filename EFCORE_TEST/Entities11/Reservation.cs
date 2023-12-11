namespace EFCORE_TEST.Entities11;

public partial class Reservation
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Customer? Customer { get; set; }
}

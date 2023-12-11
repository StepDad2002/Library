namespace EFCORE_TEST.Entities11;

public partial class Review
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? Rating { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Customer? Customer { get; set; }
}

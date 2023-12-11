namespace EFCORE_TEST.Entities11;

public partial class Staff
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public int? AddressId { get; set; }

    public string Position { get; set; } = null!;

    public decimal Salary { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Address? Address { get; set; }
}

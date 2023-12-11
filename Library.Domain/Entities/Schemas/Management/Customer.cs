using Library.Domain.Common;

namespace Library.Domain.Entities.Schemas.Management;

public class Customer : Human
{

    public virtual ICollection<FinePayment>? FinePayments { get; set; } = new List<FinePayment>();

    public virtual ICollection<Loan>? Loans { get; set; } = new List<Loan>();

    public virtual ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();

    public string Password { get; set; }
}
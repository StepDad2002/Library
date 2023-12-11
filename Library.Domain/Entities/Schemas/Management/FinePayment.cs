using Library.Domain.Common;

namespace Library.Domain.Entities.Schemas.Management;

public class FinePayment : BaseDomainEntity
{
    public int CustomerId { get; set; }

    public decimal Amount { get; set; }

    public virtual Customer Customer { get; set; }

    public DateTime PaymentDate { get; set; }
}
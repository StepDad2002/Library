using Library.Domain.Common;
using Library.Domain.Entities.Schemas.BookSchema;
using Library.Domain.Enums;

namespace Library.Domain.Entities.Schemas.Management;

public class Reservation : BaseDomainEntity
{
    public int CustomerId { get; set; }
    
    public int BookId { get; set; }

    public Status Status { get; set; }

    public virtual Book Book { get; set; }
    
    public int Amount { get; set; }

    public virtual Customer Customer { get; set; }

    public DateTime ReservationDate { get; set; }
    public DateTime DueDate { get; set; }
}
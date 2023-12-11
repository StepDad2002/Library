using Library.Domain.Entities.Schemas.BookSchema;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Domain.Common;

public abstract class ManagementBaseDomainEntity : BaseDomainEntity
{
    public int BookId { get; set; }

    public Book Book { get; set; }
    
    public int? CustomerId { get; set; }

    public Customer? Customer { get; set; }
}
using Library.Domain.Common;

namespace Library.Domain.Entities.Schemas.Management;

public class Review : ManagementBaseDomainEntity
{
    public int? Rating { get; set; }

    public string Comment { get; set; } = null!;
    
    public DateTime ReviewDate { get; set; }
}
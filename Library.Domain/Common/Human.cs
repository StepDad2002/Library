

namespace Library.Domain.Common;

public abstract class Human : BaseDomainEntity
{
    public string FName { get; set; }
    
    public string LName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}
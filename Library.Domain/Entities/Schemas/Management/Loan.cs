using Library.Domain.Common;

namespace Library.Domain.Entities.Schemas.Management;

public class Loan : ManagementBaseDomainEntity
{

    public DateTime LoanDate { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public DateTime ReturnedDate { get; set; }

    public decimal FineAmount { get; set; }
}
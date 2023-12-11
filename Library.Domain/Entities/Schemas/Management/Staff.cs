using Library.Domain.Common;
using Library.Domain.Enums;

namespace Library.Domain.Entities.Schemas.Management;

public class Staff : Human
{
    public Position Position { get; set; }

    public decimal Salary { get; set; }

    public DateTime HireDate { get; set; }
    
    public string Password { get; set; }
    
}
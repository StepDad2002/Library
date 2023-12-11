using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Loan;

public class UpdateLoanDto : BaseDto
{
    public DateTime DueDate { get; set; }
    
    public DateTime ReturnedDate { get; set; }

    public decimal FineAmount { get; set; }
}
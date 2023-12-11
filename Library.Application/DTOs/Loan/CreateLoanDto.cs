using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Loan;

public class CreateLoanDto : ILoanDto
{
    public DateTime LoanDate { get => DateTime.Now; }
    
    public DateTime ReturnedDate { get; set; }
    
    public decimal FineAmount { get; set; }
    
    public int BookId { get; set; }
    
    public int CustomerId { get; set; }
}
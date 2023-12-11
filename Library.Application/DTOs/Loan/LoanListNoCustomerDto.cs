using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Loan;

public class LoanListNoCustomerDto : BaseDto
{
    public DateTime LoanDate { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public DateTime ReturnedDate { get; set; }

    public decimal FineAmount { get; set; }
    
    public BookDtoNoReferences Book { get; set; }
    
}
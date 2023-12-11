using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;
using Library.Application.DTOs.Customer;

namespace Library.Application.DTOs.Loan;

public class LoanDto : BaseDto, ILoanDto
{
    public DateTime LoanDate { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public DateTime ReturnedDate { get; set; }

    public decimal FineAmount { get; set; }
    
    public int BookId { get; set; }

    public BookDtoNoReferences Book { get; set; }
    
    public int CustomerId { get; set; }

    public CustomerListDto Customer { get; set; }
}
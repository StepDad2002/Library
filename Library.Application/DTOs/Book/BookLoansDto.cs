using Library.Application.DTOs.Common;
using Library.Application.DTOs.Loan;

namespace Library.Application.DTOs.Book;

public class BookLoansDto : BaseDto
{
    public ICollection<LoanListDto>? Loans { get; set; }
}
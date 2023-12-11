using Library.Application.DTOs.Common;
using Library.Application.DTOs.Loan;

namespace Library.Application.DTOs.Customer;

public class CustomerLoansDto : BaseDto, IPersonDto
{
    public ICollection<LoanListNoCustomerDto>? Loans { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}
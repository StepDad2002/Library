using Library.Application.DTOs.Common;
using Library.Application.DTOs.Customer;

namespace Library.Application.DTOs.FinePayment;

public class FinePaymentDto : BaseDto, IFinePaymentDto
{
    public int CustomerId { get; set; }

    public CustomerListDto Customer { get; set; }

    public decimal Amount { get; set; }
    
    public DateTime PaymentDate { get; set; }
}
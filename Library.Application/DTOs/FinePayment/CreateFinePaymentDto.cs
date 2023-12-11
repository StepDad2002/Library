
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.FinePayment;

public class CreateFinePaymentDto : IFinePaymentDto
{
    public int CustomerId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get => DateTime.Now; }
}

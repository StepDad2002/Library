using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.FinePayment;

public class UpdateFinePaymentDto : BaseDto
{
    public decimal Amount { get; set; }
}
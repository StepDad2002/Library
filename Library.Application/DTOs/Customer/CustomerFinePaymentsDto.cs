using Library.Application.DTOs.Common;
using Library.Application.DTOs.FinePayment;

namespace Library.Application.DTOs.Customer;

public class CustomerFinePaymentsDto : BaseDto, IPersonDto
{
    public ICollection<FinePaymentListDto>? FinePayments { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}
namespace Library.Application.DTOs.Common;

public interface IFinePaymentDto
{
    public int CustomerId { get; set; }

    public decimal Amount { get; set; }
}
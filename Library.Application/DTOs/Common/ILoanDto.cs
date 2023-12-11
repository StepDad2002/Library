namespace Library.Application.DTOs.Common;

public interface ILoanDto
{
    decimal FineAmount { get; set; }
    int BookId { get; set; }
    int CustomerId { get; set; }
}
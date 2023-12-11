using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Reservation;

public class ReservationListNoCustomerDto : BaseDto
{
    public BookDtoNoReferences Book { get; set; }

    public int Amount { get; set; }
    
    public string Status { get; set; }
    
    public DateTime ReservationDate { get; set; }
    public DateTime DueDate { get; set; }
}
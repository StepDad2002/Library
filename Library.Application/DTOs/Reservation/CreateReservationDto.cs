namespace Library.Application.DTOs.Reservation;

public class CreateReservationDto 
{
    public int CustomerId { get; set; }

    public int BookId { get; set; }

    public int Amount { get; set; }
    
    public DateTime ReservationDate { get; set; }
    public DateTime DueDate { get; set; }
}


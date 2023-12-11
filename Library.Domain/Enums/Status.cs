namespace Library.Domain.Enums;

public enum Status
{
    // The reservation request has been received but not yet confirmed.
    Pending,
    //The reservation has been confirmed and is guaranteed.
    Confirmed, 
    // The customer took a book and checked in.
    CheckedIn,
    // The customer has returned the book and the reservation is complete.
    CheckedOut,
    // The reservation has been cancelled.
    Cancelled,
}
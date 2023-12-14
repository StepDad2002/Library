using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface IReservationRepository : IGenericRepository<Reservation>
{
    Task<Reservation?> GetReservationWithDetailsAsync(int id);
    Task<Reservation?> GetReservationWithDetailsAsync(int bookId, int customerId);
    Task<IReadOnlyList<Reservation>?> GetReservationsWithDetailsAsync();

    public Task<IReadOnlyList<Reservation>?> GetReservationByReservationDate(DateTime reservationDate);
    public Task<IReadOnlyList<Reservation>?> GetReservationByDueDate(DateTime dueDate);
    public Task<IReadOnlyList<Reservation>?> GetReservationByBookTitle(string bookTitle);
    public Task<IReadOnlyList<Reservation>?> GetReservationByCustomerPhone(string customerPhone);
    public Task<IReadOnlyList<Reservation>?> GetReservationByStatus(string status);

}
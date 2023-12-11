using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface IReservationRepository : IGenericRepository<Reservation>
{
    Task<Reservation?> GetReservationWithDetailsAsync(int id);
    Task<Reservation?> GetReservationWithDetailsAsync(int bookId, int customerId);
    Task<IReadOnlyList<Reservation>?> GetReservationsWithDetailsAsync();

}
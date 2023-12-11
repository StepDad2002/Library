using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class ReservationRepository(LibraryDbContext _dbContext) : GenericRepository<Reservation>(_dbContext), IReservationRepository
{
    public async Task<Reservation?> GetReservationWithDetailsAsync(int id)
    {
        return await _dbContext.Reservations
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Reservation?> GetReservationWithDetailsAsync(int bookId, int customerId)
    {
        return await _dbContext.Reservations.AsNoTracking()
            .FirstOrDefaultAsync(res => res.BookId == bookId 
                                        &&res.CustomerId == customerId);
    }

    public async Task<IReadOnlyList<Reservation>?> GetReservationsWithDetailsAsync()
    {
        return await _dbContext.Reservations
            .Include(x => x.Book)
            .ThenInclude(b => b.Publisher)
            .Include(x => x.Book)
            .ThenInclude(b => b.Authors)
            .Include(c => c.Customer)
            .ToListAsync();
    }
    
}
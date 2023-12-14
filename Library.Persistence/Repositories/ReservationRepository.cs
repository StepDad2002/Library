using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Library.Domain.Enums;
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
    
    public async Task<IReadOnlyList<Reservation>?> GetReservationByReservationDate(DateTime reservationDate)
    {
        return await _dbContext.Reservations
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.ReservationDate.Year == reservationDate.Year &&
                        x.ReservationDate.Month == reservationDate.Month &&
                        x.ReservationDate.Day == reservationDate.Day)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Reservation>?> GetReservationByDueDate(DateTime dueDate)
    {
        return await _dbContext.Reservations
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.DueDate.Year == dueDate.Year &&
                        x.DueDate.Month == dueDate.Month &&
                        x.DueDate.Day == dueDate.Day)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Reservation>?> GetReservationByBookTitle(string bookTitle)
    {
        return await _dbContext.Reservations
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Book.Title == bookTitle)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Reservation>?> GetReservationByCustomerPhone(string customerPhone)
    {
        return await _dbContext.Reservations
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Customer.Phone == customerPhone)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Reservation>?> GetReservationByStatus(string status)
    {
        return await _dbContext.Reservations
            .Include(x => x.Book)
            .Include(x => x.Customer)
            .Where(x => x.Status == (Status)Enum.Parse(typeof(Status), status))
            .ToListAsync();
    }
}
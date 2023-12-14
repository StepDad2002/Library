using Library.Application.Contracts.Persistence;
using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories;

public class FinePaymentRepository(LibraryDbContext _dbContext) : GenericRepository<FinePayment>(_dbContext), IFinePaymentRepository
{
    public async Task<FinePayment?> GetFinePaymentWithDetailsAsync(int id)
    {
        return await _dbContext.FinePayments
            .Include(x => x.Customer)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<FinePayment>?> GetFinePaymentsWithDetailsAsync()
    {
       var res =  await _dbContext.FinePayments
           .Include(x => x.Customer)
            .ToListAsync();
       return res;
    }

    public async Task<IReadOnlyList<FinePayment>?> GetFinePaymentsByDateAsync(DateTime payedOn)
    {
        var res =  await _dbContext.FinePayments
            .Include(x => x.Customer)
            .Where(x => x.PaymentDate.Year == payedOn.Year &&
                        x.PaymentDate.Month == payedOn.Month &&
                        x.PaymentDate.Day == payedOn.Day)
            .ToListAsync();

        return res;
    }

    public async Task<IReadOnlyList<FinePayment>?> GetFinePaymentsByCustomerPhoneAsync(string phone)
    {
        var res =  await _dbContext.FinePayments
            .Include(x => x.Customer)
            .Where(x => x.Customer.Phone == phone)
            .ToListAsync();
        return res;
    }
}
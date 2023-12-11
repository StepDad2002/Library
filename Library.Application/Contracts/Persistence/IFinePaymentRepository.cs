using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Contracts.Persistence;

public interface IFinePaymentRepository : IGenericRepository<FinePayment>
{
    Task<FinePayment?> GetFinePaymentWithDetailsAsync(int id);
    Task<IReadOnlyList<FinePayment>?> GetFinePaymentsWithDetailsAsync();
}
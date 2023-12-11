using Library.Application.Contracts.Persistence;
using Library.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistance;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddDbContext<LibraryDbContext>( options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LibraryConnectionString")); //TODO Add user secrets
            options.EnableSensitiveDataLogging();
        });

        service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        service.AddScoped<IAuthorRepository, AuthorRepository>();
        service.AddScoped<IBookRepository, BookRepository>();
        service.AddScoped<ICustomerRepository, CustomerRepository>();
        service.AddScoped<IFinePaymentRepository, FinePaymentRepository>();
        service.AddScoped<ILoanRepository, LoanRepository>();
        service.AddScoped<IPublisherRepository, PublisherRepository>();
        service.AddScoped<IReservationRepository, ReservationRepository>();
        service.AddScoped<IReviewRepository, ReviewRepository>();
        service.AddScoped<IShelfRepository, ShelfRepository>();
        service.AddScoped<IStaffRepository, StaffRepository>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();

        return service;
    }
}
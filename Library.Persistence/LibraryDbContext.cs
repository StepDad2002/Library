using Library.Domain.Common;
using Library.Domain.Entities.Schemas.BookSchema;
using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }
    
    public LibraryDbContext(string connectionString) : base(GetOptions(connectionString))
    {
    }

    private static DbContextOptions GetOptions(string connectionString)
    {
        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }
    
    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<Shelf> Shelves { get; set; }
    
    public DbSet<Customer> Customers { get; set; }

    public DbSet<FinePayment> FinePayments { get; set; }

    public DbSet<Loan> Loans { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Staff> Staffs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
        modelBuilder.HasDbFunction(() => GetBooksByGenre(""));
        modelBuilder.HasDbFunction(() => GetAuthorsByName(""));
    }

    [DbFunction(Name = "GetBooksByGenre", Schema = "Book")]
    public IQueryable<Book> GetBooksByGenre(string genres) => FromExpression(() => GetBooksByGenre(genres));
    
    [DbFunction(Name = "GetAuthorsByName", Schema = "Book")]
    public IQueryable<Author> GetAuthorsByName(string name) => FromExpression(() => GetAuthorsByName(name));
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entity in ChangeTracker.Entries<BaseDomainEntity>())
        {
            entity.Entity.ModifiedDate = DateTime.Now;
            entity.Entity.ModifiedBy = "SYSTEM";

            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedDate = DateTime.Now;
                entity.Entity.CreatedBy = "SYSTEM";
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}


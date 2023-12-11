using EFCORE_TEST.Entities11;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_TEST.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<FinePayment> FinePayments { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Shelf> Shelves { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Library_Development;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Authors", "Book");

            entity.Property(e => e.Fname)
                .HasMaxLength(25)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(25)
                .HasColumnName("LName");

            entity.HasMany(d => d.Books).WithMany(p => p.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthorBook",
                    r => r.HasOne<Book>().WithMany().HasForeignKey("BooksId"),
                    l => l.HasOne<Author>().WithMany().HasForeignKey("AuthorsId"),
                    j =>
                    {
                        j.HasKey("AuthorsId", "BooksId");
                        j.ToTable("AuthorBook", "Book");
                        j.HasIndex(new[] { "BooksId" }, "IX_AuthorBook_BooksId");
                    });
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Books", "Book");

            entity.HasIndex(e => e.CategoryId, "IX_Books_CategoryId");

            entity.HasIndex(e => e.Isbn, "IX_Books_ISBN").IsUnique();

            entity.HasIndex(e => e.LanguageId, "IX_Books_LanguageId");

            entity.HasIndex(e => e.PublisherId, "IX_Books_PublisherId");

            entity.HasIndex(e => e.ReservationId, "IX_Books_ReservationId");

            entity.HasIndex(e => e.ShelfId, "IX_Books_ShelfId");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Isbn).HasColumnName("ISBN");

            entity.HasOne(d => d.Category).WithMany(p => p.Books).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Language).WithMany(p => p.Books).HasForeignKey(d => d.LanguageId);

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books).HasForeignKey(d => d.PublisherId);

            entity.HasOne(d => d.Reservation).WithMany(p => p.Books).HasForeignKey(d => d.ReservationId);

            entity.HasOne(d => d.Shelf).WithMany(p => p.Books).HasForeignKey(d => d.ShelfId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categorie", "Book");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers", "Management");

            entity.HasIndex(e => e.AddressId, "IX_Customers_AddressId");

            entity.HasIndex(e => e.Phone, "IX_Customers_Phone").IsUnique();

            entity.Property(e => e.Fname).HasColumnName("FName");
            entity.Property(e => e.Lname).HasColumnName("LName");
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers).HasForeignKey(d => d.AddressId);
        });

        modelBuilder.Entity<FinePayment>(entity =>
        {
            entity.ToTable("FinePayments", "Management");

            entity.HasIndex(e => e.CustomerId, "IX_FinePayments_CustomerId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.FinePayments).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Languages", "Book");

            entity.Property(e => e.Code).HasMaxLength(10);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.ToTable("Loans", "Management");

            entity.HasIndex(e => e.BookId, "IX_Loans_BookId");

            entity.HasIndex(e => e.CustomerId, "IX_Loans_CustomerId");

            entity.Property(e => e.FineAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Book).WithMany(p => p.Loans).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Loans).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToTable("Publishers", "Book");

            entity.HasIndex(e => e.AddressId, "IX_Publishers_AddressId");

            entity.HasIndex(e => e.Phone, "IX_Publishers_Phone").IsUnique();

            entity.HasOne(d => d.Address).WithMany(p => p.Publishers).HasForeignKey(d => d.AddressId);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservations", "Management");

            entity.HasIndex(e => e.CustomerId, "IX_Reservations_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews", "Management");

            entity.HasIndex(e => e.BookId, "IX_Reviews_BookId");

            entity.HasIndex(e => e.CustomerId, "IX_Reviews_CustomerId");

            entity.Property(e => e.Comment).HasMaxLength(350);

            entity.HasOne(d => d.Book).WithMany(p => p.Reviews).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.ToTable("Shelves", "Book");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable("Staffs", "Management");

            entity.HasIndex(e => e.AddressId, "IX_Staffs_AddressId");

            entity.HasIndex(e => e.Phone, "IX_Staffs_Phone").IsUnique();

            entity.Property(e => e.Fname).HasColumnName("FName");
            entity.Property(e => e.Lname).HasColumnName("LName");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Address).WithMany(p => p.Staff).HasForeignKey(d => d.AddressId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

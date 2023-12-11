using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Loans", "Management");

        builder.HasOne(d => d.Book).WithMany(p => p.Loans)
            .HasForeignKey(d => d.BookId).OnDelete((DeleteBehavior.NoAction));

        builder.HasOne(d => d.Customer).WithMany(p => p.Loans)
            .HasForeignKey(d => d.CustomerId).OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.DueDate).HasColumnType("datetime");
        builder.Property(x => x.ReturnedDate).HasColumnType("datetime");
        builder.Property(x => x.LoanDate).HasColumnType("datetime");
    }
}
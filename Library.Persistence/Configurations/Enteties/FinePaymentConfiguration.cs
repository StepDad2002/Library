using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class FinePaymentConfiguration : IEntityTypeConfiguration<FinePayment>
{
    public void Configure(EntityTypeBuilder<FinePayment> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("FinePayments", "Management");

        builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
        builder.Property(e => e.PaymentDate).HasColumnType("datetime");

        builder.HasOne(d => d.Customer).WithMany(p => p.FinePayments)
            .HasForeignKey(d => d.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
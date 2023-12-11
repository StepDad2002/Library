using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        
        
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Customers", "Management");

        builder.HasIndex(e => e.Phone, "IX_Customers_Phone").IsUnique();
        builder.HasIndex(e => e.Email, "IX_Customers_Email").IsUnique();

        builder.Property(e => e.Phone).HasMaxLength(15);

        builder.Property(x => x.FName).HasMaxLength(25);
        builder.Property(x => x.LName).HasMaxLength(25);
        builder.Property(x => x.Phone).HasMaxLength(20);
        
    }
}
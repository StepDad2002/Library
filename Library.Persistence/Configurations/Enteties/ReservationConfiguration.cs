using Library.Domain.Entities.Schemas.Management;
using Library.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Reservations", "Management");

        builder.Property(x => x.Status).HasConversion(
            convertToProviderExpression: to => to.ToString(),
            convertFromProviderExpression: from => Enum.Parse<Status>(from, true)
        );

        builder.Property(x => x.Status).HasDefaultValue(Status.Pending);

        builder.HasOne(d => d.Customer)
            .WithMany(p => p.Reservations)
            .HasForeignKey(d => d.CustomerId).OnDelete(DeleteBehavior.Cascade);
        
   
    }
}
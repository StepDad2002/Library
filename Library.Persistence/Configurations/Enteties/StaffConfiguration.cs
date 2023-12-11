using Library.Domain.Entities.Schemas.Management;
using Library.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Staffs", "Management");

        builder.HasIndex(e => e.Phone, "IX_Staffs_Phone").IsUnique();
        builder.HasIndex(e => e.Email, "IX_Staffs_Email").IsUnique();
        builder.Property(e => e.HireDate).HasColumnType("datetime");

        builder.Property(e => e.FName).HasMaxLength(25);
        builder.Property(e => e.LName).HasMaxLength(25);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

        builder.Property(x => x.Position).HasConversion(
            convertToProviderExpression: to => to.ToString(),
            convertFromProviderExpression: from => Enum.Parse<Position>(from, true)
        );

        
    }
}
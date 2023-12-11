using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.Property(e => e.Name).HasMaxLength(75);
        builder.ToTable("Publishers", "Book");

        builder.HasIndex(e => e.Phone, "IX_Publishers_Phone").IsUnique();
        builder.HasIndex(e => e.Name, "IX_Publishers_Name").IsUnique();

        builder.HasMany(x => x.Books).WithOne(x => x.Publisher)
            .HasForeignKey(f => f.PublisherId).OnDelete(DeleteBehavior.NoAction);
    }
}
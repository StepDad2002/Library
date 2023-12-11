using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
{
    public void Configure(EntityTypeBuilder<Shelf> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Shelves", "Book");

        builder.HasMany(s => s.Books)
            .WithOne(b => b.Shelf)
            .HasForeignKey(f => f.ShelfId)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}
using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Persistance.Configurations.Enteties;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Books", "Book", b =>
        {
            b.HasCheckConstraint("CK_Book_CopiesAvailable", "CopiesAvailable >= 0");
        });

        builder.HasIndex(e => e.Isbn, "IX_Books_ISBN").IsUnique();

        builder.Property(x => x.PublicationDate)
            .HasColumnType("date");

        builder.Property(e => e.Description).HasMaxLength(300);
        builder.Property(e => e.Title).HasMaxLength(100);
        builder.Property(e => e.Isbn).HasColumnName("ISBN").HasMaxLength(15);
        

        builder.HasOne(d => d.Publisher).WithMany(p => p.Books)
            .HasForeignKey(d => d.PublisherId).OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Shelf).WithMany(p => p.Books)
            .HasForeignKey(d => d.ShelfId).OnDelete(DeleteBehavior.SetNull);

        var splitStringConverter = new ValueConverter<string[], string>(
            v => string.Join(", ", v.Distinct()),
            v => v.Split(',',StringSplitOptions.TrimEntries).Distinct().ToArray());
        builder.Property(x => x.Genres).HasConversion(splitStringConverter, 
            new ValueComparer<string[]>((c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => (string[])c.Clone()));
    }
}
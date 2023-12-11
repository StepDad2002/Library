using Library.Domain.Entities.Schemas.BookSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(x => x.FName)
            .IsRequired()
            .HasMaxLength(25);
        
        builder.Property(x => x.MName)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(x => x.LName)
            .IsRequired()
            .HasMaxLength(25);

        builder.Ignore(x => x.FullName);

        builder.Property(x => x.BirthDay)
            .HasColumnType("date");

        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Authors", "Book");

        builder.HasMany(e => e.Books).WithMany(p => p.Authors)
            .UsingEntity<Dictionary<string, object>>("AuthorsBook",
                configureRight: r => r.HasOne<Book>().WithMany().HasForeignKey("BooksId").OnDelete(DeleteBehavior.Cascade),
                configureLeft: l => l.HasOne<Author>().WithMany().HasForeignKey("AuthorsId").OnDelete(DeleteBehavior.NoAction),
                configureJoinEntityType: j =>
                {
                    j.HasKey("AuthorsId", "BooksId");
                    j.ToTable("AuthorBook", "Book");
                    j.HasIndex(new[] { "BooksId" }, "IX_AuthorBook_BooksId");
                });
    }
}
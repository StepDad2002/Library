using Library.Domain.Entities.Schemas.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.Configurations.Enteties;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.ToTable("Reviews", "Management", b =>
        {
            b.HasCheckConstraint("CK_Review_Rating", "Rating >= 1 AND Rating <= 10");
        });

        builder.Property(x => x.ReviewDate).HasColumnType("datetime");

        builder.Property(e => e.Comment).HasMaxLength(500);

        builder.HasOne(d => d.Book)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Customer)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}
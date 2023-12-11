using Library.Domain.Common;

namespace Library.Domain.Entities.Schemas.BookSchema;

public class Shelf : BaseDomainEntity
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Book>? Books { get; set; }
}
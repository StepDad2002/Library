using Library.Domain.Common;

namespace Library.Domain.Entities.Schemas.BookSchema;

public class Publisher : BaseDomainEntity
{
    public string Name { get; set; }

    public string Phone { get; set; }

    public string? WebSite { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}
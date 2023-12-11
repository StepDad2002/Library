using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Shelf;

public class ShelfDto : BaseDto, IShelfDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<BookDtoNoReferences> Books { get; set; }
}
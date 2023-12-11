using Library.Application.DTOs.Book;
using Library.Application.DTOs.Common;

namespace Library.Application.DTOs.Author;

public class AuthorDto : BaseDto, IAuthorDto
{
    public string FName { get; set; }

    public string MName { get; set; }
    public string LName { get; set; }

    public string? Nationality { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Biography { get; set; }

    public ICollection<BookDtoNoReferences> Books { get; set; }
}
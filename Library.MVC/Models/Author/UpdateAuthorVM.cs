using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models.Author;

public class UpdateAuthorVM : CreateAuthorVM
{
    [Required,Range(0,int.MaxValue,MinimumIsExclusive = true)] public int Id { get; set; }

    [MaxLength(50, ErrorMessage = "{0} should have maximum 50 characters")]
    public string? Nationality { get; set; }

    [DateRange( "1/1/0001", "12/31/9999", ShouldNotBeInFuture = true, ErrorMessage = "Date must be between '1/1/0001' and '12/31/9999'")]
    public DateTime? BirthDay { get; set; }

    [MaxLength(500, ErrorMessage = "{0} should have maximum 500 characters")]
    public string? Biography { get; set; }
}
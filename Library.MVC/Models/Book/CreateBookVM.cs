using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;
using Library.MVC.Models.Author;
using Library.MVC.Models.Publisher;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Models.Book;

public class CreateBookVM : IBookVM
{
    [Required(ErrorMessage = "{0} is required"),
     MaxLength(120)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "{0} is required"),
     MinLength(7)]
    public string Isbn { get; set; }
    [Required]
    public string Categorie { get; set; }
    [Required, MinLength(1), NotEmpty(ErrorMessage = "Genre can not be empty")]
    public string[] Genres { get; set; }
    [Required]
    public string Language { get; set; }
    [Required, Range(1, 30000, MinimumIsExclusive = false, ErrorMessage = "The value for {0} must be greater or equat to 1 and less then or equal to 30000")]
    public int CopiesAvailable { get; set; }

    [DateRange( "1/1/0001", "12/31/9999", ErrorMessage = "Allowed date range is '1/1/0001' to '12/31/9999'"),DateNotInFuture(ErrorMessage = "The date can not be greater than today")]
    public DateTime PublicationDate { get; set; }

    public int? ShelfId { get; set; }
    
    [Required]
    public CreatePublisherVM Publisher { get; set; }

    [Required, MinLength(1)]
    public ICollection<CreateAuthorVM> Authors { get; set; }
}
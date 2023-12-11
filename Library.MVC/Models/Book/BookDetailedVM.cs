using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;
using Library.MVC.Models.Author;
using Library.MVC.Models.Publisher;
using Library.MVC.Models.Shelf;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Models.Book;

public class BookDetailedVM : IBookVM
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "{0} is required"),
     MaxLength(120)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "{0} is required"),
     MinLength(7), Remote("CheckEmail", "Book")]
    public string Isbn { get; set; }
    [Required]
    public string Categorie { get; set; }
    [Required, MinLength(1)]
    public string[] Genres { get; set; }
    [Required]
    public string Language { get; set; }
    [Required]
    public int CopiesAvailable { get; set; }

    [DateRange( "1/1/0001", "12/31/9999"),DateNotInFuture]
    public DateTime PublicationDate { get; set; }
    
    public double? AvgRating { get; set; }
    
    public string? Description { get; set; }
    
    public ShelfVM Shelf { get; set; }
    
    public PublisherVM Publisher { get; set; }
    
    public ICollection<AuthorVM> Authors { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Models.Book;

public interface IBookVM
{
    public string Title { get; set; }
    
    public string Isbn { get; set; }

    public string Categorie { get; set; }

    public string[] Genres { get; set; }

    public string Language { get; set; }

    public int CopiesAvailable { get; set; }


    public DateTime PublicationDate { get; set; }
}
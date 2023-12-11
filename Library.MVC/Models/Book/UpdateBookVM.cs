﻿using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Models.Book;

public class UpdateBookVM : IBookVM
{
    [Range(0, Int32.MaxValue, MinimumIsExclusive = true)]
    public int Id { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; }

[Range(0,10, MinimumIsExclusive = false, MaximumIsExclusive = false)]
    public double? AvgRating { get; set; }

    [Required(ErrorMessage = "{0} is required"),
     MaxLength(120)]
    public string Title { get; set; }

    [Required(ErrorMessage = "{0} is required"),
     MinLength(7)]
    public string Isbn { get; set; }

    [Required] public string Categorie { get; set; }
    [Required, MinLength(1)] public string[] Genres { get; set; }
    [Required] public string Language { get; set; }
    [Required] public int CopiesAvailable { get; set; }

    [DateRange("1/1/0001", "12/31/9999"), DateNotInFuture]
    public DateTime PublicationDate { get; set; }
}
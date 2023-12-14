using System.ComponentModel.DataAnnotations;
using Library.MVC.CustomValidationAttrs;

namespace Library.MVC.Models;

public class ReviewSearchOptionsVM : ManagementBaseSearchOptionsVM
{
    public DateTime? ReviewDate { get; set; }
   
    [Range(1, 10)]
    public int MinRating { get; set; }

    [Range(1, 10)]
    public int MaxRating { get; set; }
}
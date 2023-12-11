using Library.MVC.Models.Author;
using Library.MVC.Models.Publisher;

namespace Library.MVC.Models.Book;

public class BookListVM
{
    
        public int Id { get; set; }

        
        public UpdatePublisherVM Publisher { get; set; }

        
        public DateTime PublicationDate { get; set; }

        
        public string[] Genres { get; set; }
        public string Isbn { get; set; }

        
        public string? Categorie { get; set; }

        
        public ICollection<AuthorVM>? Authors { get; set; }

        
        public string? Title { get; set; }

        
        public string? Language { get; set; }


        public double? AvgRating { get; set; }

        
        public string? Description { get; set; }

    
}
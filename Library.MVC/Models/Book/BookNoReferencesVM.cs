namespace Library.MVC.Models.Book;

public class BookNoReferencesVM
{
  
        public int Id { get; set; }
        
        public string Title { get; set; }

      
        public string Isbn { get; set; } 

       
        public ICollection<string> Genres { get; set; } 

      
        public string Categorie { get; set; }

        public string Language { get; set; } 

      
        public DateTime PublicationDate { get; set; } 


        public int ShelfId { get; set; }
        
        public int CopiesAvailable { get; set; }

  
        public int PublisherId { get; set; }

     
        public ICollection<int> AuthorsId { get; set; }
}
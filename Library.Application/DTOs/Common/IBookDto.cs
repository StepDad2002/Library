namespace Library.Application.DTOs.Common;

public interface IBookDto
{
    public string Title { get; set; }

    public string[] Genres { get; set; }

    public string Language { get; set; }

    public string Categorie { get; set; }
    
}
using Library.MVC.Models.Author;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IAuthorService
{
    Task<List<AuthorVM>> GetAuthors();
    Task<AuthorVM> GetAuthor(int id);
    Task<List<AuthorVM>> GetAuthorsByName(string name);
    Task<Response<int>> UpdateAuthor(UpdateAuthorVM author);
    Task<List<AuthorVM>> GetTopAuthors(int i);
    Task<List<AuthorVM>> GetAuthorsByBirthday(DateTime birthday);
    Task<List<AuthorVM>> GetAuthorsByNationality(string nationality);
}
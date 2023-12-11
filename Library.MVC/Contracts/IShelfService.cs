using Library.MVC.Models.Shelf;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IShelfService
{
    Task<List<ShelfVM>> GetShelves();
    Task<ShelfVM> GetShelf(int id);
    Task<List<ShelfVM>> GetShelves(string name);
    Task<Response<int>> UpdateShelf(UpdateShelfVM shelf);
    Task<Response<int>> CreateShelf(CreateShelfVM shelf);
    Task<Response<int>> DeleteShelf(int id);
    Task<Response<int>> UpdateShelfBooks(int id, ICollection<int> bookIds);
}
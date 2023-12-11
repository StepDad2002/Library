using Library.MVC.Models.Publisher;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IPublisherService
{
    Task<List<PublisherListVM>> GetPublishers();
    Task<List<PublisherVM>> GetPublishersForManagement();
    Task<PublisherVM> GetPublisher(int id);
    Task<PublisherVM?> GetPublisher(string name);
    Task<Response<int>> UpdatePublisher(UpdatePublisherVM publisher);
    Task<List<PublisherListVM>> GetTopPublishers(int i);
}
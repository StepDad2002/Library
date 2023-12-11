using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.Publisher;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class PublisherService(ILocalStorageService localStorage, IClient client, IMapper mapper)
    : BaseHttpService(localStorage, client), IPublisherService
{
    public async Task<List<PublisherListVM>> GetPublishers()
    {
        var publisherDtos = await _client.PublisherAllAsync();
        return mapper.Map<List<PublisherListVM>>(publisherDtos);
    }

    public async Task<List<PublisherVM>> GetPublishersForManagement()
    {
        var publisherDtos = await _client.PublisherAllAsync();
        return mapper.Map<List<PublisherVM>>(publisherDtos);
    }

    public async Task<PublisherVM> GetPublisher(int id)
    {
        var publisherDto = await _client.PublisherGETAsync(id);
        return mapper.Map<PublisherVM>(publisherDto);
    }


    public async Task<PublisherVM> GetPublisher(string title)
    {
        var publisherDto = await _client.SearchAsync(title);
        return mapper.Map<PublisherVM>(publisherDto);
    }

    public async Task<Response<int>> UpdatePublisher(UpdatePublisherVM publisher)
    {
        try
        {
            var authorDto = mapper.Map<UpdatePublisherDto>(publisher);
            var response = await _client.PublisherPUTAsync(authorDto);
            return new Response<int>()
                { Successs = response.Success, Data = authorDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<List<PublisherListVM>> GetTopPublishers(int limit)
    {
        var publisherDtos = await _client.Top3Async(limit);
        return mapper.Map<List<PublisherListVM>>(publisherDtos);
    }
}
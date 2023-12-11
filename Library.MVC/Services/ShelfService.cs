using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.Shelf;
using Library.MVC.Services.Base;

namespace Library.MVC.Services;

public class ShelfService(ILocalStorageService localStorage, IClient client, IMapper mapper) :
    BaseHttpService(localStorage, client), IShelfService
{
    public async Task<List<ShelfVM>> GetShelves()
    {
        var shelfDtos = await _client.ShelfAllAsync();
        return mapper.Map<List<ShelfVM>>(shelfDtos);
    }

    public async Task<ShelfVM> GetShelf(int id)
    {
        var shelfDto = await _client.ShelfGETAsync(id);
        return mapper.Map<ShelfVM>(shelfDto);
    }

    public async Task<List<ShelfVM>> GetShelves(string name)
    {
        ICollection<ShelfDto> shelfDto = await _client.SearchAllAsync(name);
        return mapper.Map<List<ShelfVM>>(shelfDto);
    }

    public async Task<Response<int>> UpdateShelf(UpdateShelfVM shelf)
    {
        try
        {
            var shelfDto = mapper.Map<UpdateShelfDto>(shelf);
            var response = await _client.ShelfPUTAsync(shelfDto);
            return new Response<int>()
                { Successs = response.Success, Data = shelfDto.Id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> CreateShelf(CreateShelfVM shelf)
    {
        try
        {
            var response = new Response<int>();
            var createShelfDto = mapper.Map<CreateShelfDto>(shelf);
            var apiResponse = await _client.ShelfPOSTAsync(createShelfDto);

            if (apiResponse.Success)
            {
                response.Data = apiResponse.Id;
                response.Successs = apiResponse.Success;
                response.Message = response.Message;
            }
            else
            {
                response.ValidationErrors = FlattErrors(apiResponse.Errors);
            }

            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }

    public async Task<Response<int>> DeleteShelf(int id)
    {
        try
        {
            await _client.ShelfDELETEAsync(id);
            return new Response<int>() { Successs = true, Message = "Deleted successfully" };
        }
        catch (ApiException e)
        {
            return ConvertApiException(e);
        }
    }

    public async Task<Response<int>> UpdateShelfBooks(int id, ICollection<int> bookIds)
    {
        try
        {
            var response = await _client.PutBooksAsync(id, bookIds);
            return new Response<int>()
                { Successs = response.Success, Data = id, Message = response.Message,ValidationErrors = FlattErrors(response.Errors) };
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }
    }
}
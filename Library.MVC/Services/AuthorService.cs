using AutoMapper;
using Library.MVC.Contracts;
using Library.MVC.Models.Author;
using Library.MVC.Services.Base;
namespace Library.MVC.Services;

public class AuthorService(ILocalStorageService localStorage, IClient httpClient, IMapper mapper) : 
    BaseHttpService(localStorage, httpClient), IAuthorService
{
    public async Task<List<AuthorVM>> GetAuthors()
    {
        var authors = await _client.AuthorAllAsync();
        return mapper.Map<List<AuthorVM>>(authors);
    }

    public async Task<AuthorVM> GetAuthor(int id)
    {
        var author = await _client.AuthorGETAsync(id);
        return mapper.Map<AuthorVM>(author);
    }

    public async Task<List<AuthorVM>> GetAuthorsByName(string name)
    {
        var author = await _client.NameAsync(name);
        return mapper.Map<List<AuthorVM>>(author);
    }


    public async Task<Response<int>> UpdateAuthor(UpdateAuthorVM author)
    {
        try
        {
            var authorDto = mapper.Map<UpdateAuthorDto>(author);
            var response = await _client.AuthorPUTAsync(authorDto);
            return new Response<int>()
                { Successs = response.Success, Data = authorDto.Id, Message = response.Message, ValidationErrors = FlattErrors(response.Errors)};
        }
        catch (ApiException ex)
        {
            return ConvertApiException(ex);
        }

    }

    public async Task<List<AuthorVM>> GetTopAuthors(int limit)
    {
        var authors = await _client.TopAsync(limit);
        return mapper.Map<List<AuthorVM>>(authors);
    }

    public async Task<List<AuthorVM>> GetAuthorsByBirthday(DateTime birthday)
    {
        var authors = await _client.BirthdayAsync(birthday);
        return mapper.Map<List<AuthorVM>>(authors);
    }

    public async Task<List<AuthorVM>> GetAuthorsByNationality(string nationality)
    {
        var authors = await _client.NationalityAsync(nationality);
        return mapper.Map<List<AuthorVM>>(authors);
    }
}
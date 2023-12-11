namespace Library.MVC.Services.Base;

public partial class Client : IClient
{
    public HttpClient HttpClient
    {
        get => _httpClient;
    }
}
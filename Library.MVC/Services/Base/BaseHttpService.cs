using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Library.MVC.Contracts;

namespace Library.MVC.Services.Base;

public class BaseHttpService(ILocalStorageService localStorage, IClient client)
{
    protected readonly ILocalStorageService _localStorage = localStorage;

    protected IClient _client = client;

    protected Response<int> ConvertApiException(ApiException ex)
    {
        switch (ex.StatusCode)
        {
            case 400:
                return new Response<int>()
                {
                    Message = "Validation errors have occured",
                    ValidationErrors = ParseJsonErrors(ex.Response),
                    Successs = false
                };
            case 404:
                return new Response<int>()
                {
                    Message = "The requested item was not found",
                    ValidationErrors = ex.Response,
                    Successs = false
                };
            case 204:
                return new Response<int>()
                {
                    Message = "The requested item was deleted. No content was supplied",
                    ValidationErrors = ex.Response,
                    Successs = true
                };
            default:
                return new Response<int>()
                {
                    Message = "Something went wronf, try again",
                    ValidationErrors = ex.Response,
                    Successs = false
                };
        }
    }

    protected string FlattErrors(ICollection<string>? errors)
    {
        if(errors is null || errors.Count < 1)
            return string.Empty; 
        return string.Join('\n', errors);
    }

    protected string ParseJsonErrors(string errors)
    {
        StringBuilder result = new();
        result.Append("{").Append("\n");
        JsonDocument document = JsonDocument.Parse(errors);

        JsonElement root = document.RootElement;

        if (root.TryGetProperty("errors", out JsonElement errorsElement))
        {
            foreach (JsonProperty errorProperty in errorsElement.EnumerateObject())
            {
                result.Append(errorProperty.Name).Append(": ");
                JsonElement errorMessagesElement = errorProperty.Value;

                foreach (JsonElement errorMessageElement in errorMessagesElement.EnumerateArray())
                {
                    result.Append(errorMessageElement.GetString()).Append("\n");
                }
            }
        }

        result.Append("}");
        return result.ToString();
    }
}
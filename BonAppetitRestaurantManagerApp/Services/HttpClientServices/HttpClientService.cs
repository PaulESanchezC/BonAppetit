using System.Net.Http.Json;
using Models.ApiRequestModels;
using Models.ResponseModels;
using Services.ApiRouteProvider;

namespace Services.HttpClientServices;

public class HttpClientService<T> : IHttpClientService<T>, IApiRouteProvider
where T : class
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<T>> SendAsync(ApiRequest apiRequest)
    {
        var apiUrl = await GetApiRoute(apiRequest.RouteName);
        var route = _httpClient.BaseAddress!.ToString();

        if (apiRequest.HttpMethod == HttpMethod.Get)
            if (apiRequest.GetQueries.Any())
                apiRequest.GetQueries.Aggregate(route, (current, query) => string.Format(current, query));

        if (apiRequest.HttpMethod == HttpMethod.Delete)
        {
            if (!apiRequest.GetQueries.Any())
                return await ResponseSingleBuilderTask(false, 500, "HttpDelete error",
                    "The HttpDelete method requires 1 query parameter", null);
                
            route = string.Format(route, apiRequest.GetQueries.FirstOrDefault());
        }

        var request = new HttpRequestMessage(apiRequest.HttpMethod, route);

        if (apiRequest.HttpMethod == HttpMethod.Post || apiRequest.HttpMethod == HttpMethod.Put)
        {
            if (apiRequest.PostBody is null)
                return await ResponseSingleBuilderTask(false, 500, "Http body error",
                    "The Http methods POST and PUT requires a body object", null);
            request.Content = new StringContent(JsonConvert)
        }



    }

    public async Task<string?> GetApiRoute(string routeName)
    {
        return await _httpClient.GetFromJsonAsync<string>(routeName);
    }

    public Task<Response<T>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message, T? responseObject)
    {
        var responseObjectDto = new List<T> { _mapper.Map<TDto>(responseObject) };

        var response = new Response<TDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }
}
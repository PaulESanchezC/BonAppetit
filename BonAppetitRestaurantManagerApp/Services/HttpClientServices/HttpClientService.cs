namespace Services.HttpClientServices;

public class HttpClientService<T> : IHttpClientService<T>
where T: class
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string GetBaseUrl()
    {
        return _httpClient.BaseAddress.ToString();
    }
}
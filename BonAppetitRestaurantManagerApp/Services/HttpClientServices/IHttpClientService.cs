namespace Services.HttpClientServices;

public interface IHttpClientService<T>
where T:class
{
    String GetBaseUrl();
}
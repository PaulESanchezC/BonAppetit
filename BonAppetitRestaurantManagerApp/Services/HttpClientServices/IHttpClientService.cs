using Models.ApiRequestModels;
using Models.ResponseModels;

namespace Services.HttpClientServices;

public interface IHttpClientService<T>
    where T : class
{
    Task<Response<T>> SendAsync(ApiRequest apiRequest);

    Task<Response<T>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        T? responseObject);
}
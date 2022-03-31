using Models.ApiRequestModels;
using Models.ResponseModels;

namespace Services.ApiRequestServices;

public interface IApiRequestService<T> where T: class
{
    Task<Response<T>> SendAsync(ApiRequest<T> apiRequest);
    Task<Response<T>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        T? responseObject);
}
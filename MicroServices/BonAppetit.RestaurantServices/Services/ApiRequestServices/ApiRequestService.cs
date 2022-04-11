using System.Net.Http.Headers;
using System.Text;

using Models.ApiRequestModels;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Services.ApiRequestServices;

public class ApiRequestService<T> : IApiRequestService<T>
where T : class
{
    private IHttpClientFactory _httpClientFactory;

    public ApiRequestService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<Response<T>> SendAsync(ApiRequest<T> apiRequest)
    {
        var request = new HttpRequestMessage(apiRequest.HttpMethod, apiRequest.ApiUrl);
        if (apiRequest.HttpMethod == HttpMethod.Post)
            request.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8,
                "application/json");

        if (apiRequest.JwtToken is not null)
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", apiRequest.JwtToken);
        
        if (apiRequest.RestaurantServiceIdToken is not null)
            request.Headers.Authorization = new AuthenticationHeaderValue("serviceIdToken", apiRequest.JwtToken);

        var client = _httpClientFactory.CreateClient(typeof(T).Name);
        var responseMessage = await client.SendAsync(request);
        var responseString = await responseMessage.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<T>>(responseString);
        
        if (response is not null)
            return response;

        return await ResponseSingleBuilderTask(false, 404, "No Response", $"No Response for {typeof(T).Name}, request failed",null);
    }

    public Task<Response<T>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message, T? responseObject)
    {
        var responseObjectList = new List<T>();

        if (responseObject != null)
            responseObjectList.Add(responseObject);

        var response = new Response<T>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectList
        };
        return Task.FromResult(response);
    }
}
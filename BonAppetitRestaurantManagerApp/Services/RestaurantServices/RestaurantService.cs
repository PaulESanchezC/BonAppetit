using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Models.ResponseModels;
using Models.RestaurantModels;
using Newtonsoft.Json;
using StaticData;

namespace Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;

    public RestaurantService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
    }

    #region IRestaurantService

    public async Task<Response<Restaurant>?> GetRestaurantByIdAsync(string restaurantId)
    {
        var route = "https://localhost:44310/api/Restaurant/GetSingleRestaurantById/{0}";
        route = string.Format(route, restaurantId);
        var request = new HttpRequestMessage(HttpMethod.Get, route);

        var jwtToken = await _localStorage.GetItemAsync<string>(LocalStorage.JwtToken);
        if (jwtToken is not null)
            request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, jwtToken);

        var responseMessage = await _httpClient.SendAsync(request);
        var responseString = await responseMessage.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Restaurant>>(responseString);
        return response;
    }

    public async Task<Response<Restaurant>> CreateSingleRestaurant(RestaurantCreateVm restaurantToCreate)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Restaurant>> UpdateSingleRestaurant(Restaurant restaurantToUpdate)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> DeleteSingleRestaurant(string restaurantId)
    {
        throw new NotImplementedException();
    }

    #endregion
}
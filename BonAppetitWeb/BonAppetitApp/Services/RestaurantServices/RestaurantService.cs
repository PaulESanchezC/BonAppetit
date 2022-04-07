using Models.ResponseModels;
using Models.RestaurantModels;
using Newtonsoft.Json;

namespace Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    private readonly HttpClient _httpClient;

    public RestaurantService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Restaurant>> GetAllRestaurantsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44310/api/Restaurant/GetAllRestaurants");
        var client = await _httpClient.SendAsync(request);

        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Restaurant>>(responseString);
        return response!;
    }

    public async Task<Response<Restaurant>> GetSingleRestaurantAsync(string restaurantId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44310/api/Restaurant/GetSingleRestaurantById/{restaurantId}");
        var client = await _httpClient.SendAsync(request);

        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Restaurant>>(responseString);
        return response!;
    }
}
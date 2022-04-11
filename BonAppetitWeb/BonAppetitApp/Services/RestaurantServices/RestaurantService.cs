using Models.ResponseModels;
using Models.RestaurantModels;
using Models.TableReservationBracketsModels;
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

    public async Task<Response<TableReservationBracket>> GetAllAvailableReservationBracketsForRestaurant(string restaurantId, string dateOfRequest)
    {
        var route = "https://localhost:44310/api/AvailableRestaurantTables/GetAllAvailableReservationBracketsForRestaurant/{0}/{1}";
        route = string.Format(route, restaurantId, dateOfRequest);

        var request = new HttpRequestMessage(HttpMethod.Get, route);
        var client = await _httpClient.SendAsync(request);

        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<TableReservationBracket>>(responseString);
        return response!;
    }
}
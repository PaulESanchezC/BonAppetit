using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Models.ResponseModels;
using Models.RestaurantModels;
using Newtonsoft.Json;
using StaticData;

namespace Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenProvider _accessToken;
    private string Token { get; set; }
    public RestaurantService(HttpClient httpClient, IAccessTokenProvider accessToken)
    {
        _httpClient = httpClient;
        _accessToken = accessToken;
    }

    public async Task<Response<Restaurant>> GetRestaurantAsync(string restaurantId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44310/api/Restaurant/GetSingleRestaurantById/{restaurantId}");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Restaurant>>(responseString);
        return response!;
    }
    public async Task<Response<Restaurant>> CreateRestaurantAsync(RestaurantCreate restaurantToCreate)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44310/api/Restaurant/CreateSingleRestaurant");
        request.Content = new StringContent(JsonConvert.SerializeObject(restaurantToCreate), Encoding.UTF8,
            "Application/json");

        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Restaurant>>(responseString);

        return response!;
    }


    #region Helper Methods

    private async Task GetTokenAsync()
    {
        var tokenProvider = await _accessToken.RequestAccessToken();
        tokenProvider.TryGetToken(out var token);
        Token = token.Value;
    }

    #endregion
}
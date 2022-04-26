using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
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
    private readonly AuthenticationStateProvider _authState;

    private string RestaurantId { get; set; }
    private string Token { get; set; }
    public RestaurantService(HttpClient httpClient, IAccessTokenProvider accessToken, AuthenticationStateProvider authState)
    {
        _httpClient = httpClient;
        _accessToken = accessToken;
        _authState = authState;

        RestaurantId = "";
        Token = "";
    }

    public async Task<Response<Restaurant>> GetRestaurantAsync()
    {
        await GetRestaurantIdAsync();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44310/api/Restaurant/GetSingleRestaurantById/{RestaurantId}");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Restaurant>>(responseString);
        return response!;
    }
    public async Task<Response<Restaurant>> CreateRestaurantAsync(RestaurantCreate restaurantToCreate)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44310/api/Restaurant/CreateSingleRestaurant");
        request.Content = new StringContent(JsonConvert.SerializeObject(restaurantToCreate), Encoding.UTF8,
            "Application/json");

        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Restaurant>>(responseString);

        return response!;
    }
    public async Task<Response<Restaurant>> UpdateRestaurantAsync(RestaurantUpdate restaurantToUpdate)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44310/api/Restaurant/UpdateSingleRestaurant");
        request.Content = new StringContent(JsonConvert.SerializeObject(restaurantToUpdate), Encoding.UTF8,
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

    private async Task GetRestaurantIdAsync()
    {
        var userClaims = await _authState.GetAuthenticationStateAsync();
        RestaurantId = userClaims.User.FindFirst(claim => claim.Type == "sub")!.Value;
    }

    #endregion
}
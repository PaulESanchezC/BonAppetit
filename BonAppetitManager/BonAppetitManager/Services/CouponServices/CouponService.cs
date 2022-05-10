using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Models.ResponseModels;
using Models.RestaurantCoupons;
using Newtonsoft.Json;
using StaticData;

namespace Services.CouponServices;

public class CouponService : ICouponService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenProvider _accessToken;
    private readonly AuthenticationStateProvider _authState;
    private string RestaurantId { get; set; }
    private string Token { get; set; }
    public CouponService(AuthenticationStateProvider authState, IAccessTokenProvider accessToken, HttpClient httpClient)
    {
        RestaurantId = "";
        Token = "";
        _authState = authState;
        _accessToken = accessToken;
        _httpClient = httpClient;
    }

    public async Task<Response<RestaurantCoupons>> GetRestaurantCoupons()
    {
        await GetRestaurantIdAsync();
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://localhost:44329/api/RestaurantCouponControllers/GetRestaurantCoupons/{RestaurantId}");

        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<RestaurantCoupons>>(responseString);

        return response!;
    }

    public object JwtBearerDefaults { get; set; }

    public async Task<Response<RestaurantCoupons>> CreateARestaurantCoupon(RestaurantCouponsCreate restaurantCouponsCreate)
    {
        await GetRestaurantIdAsync();
        var request = new HttpRequestMessage(HttpMethod.Post,
            "https://localhost:44329/api/RestaurantCouponControllers/CreateRestaurantCoupons");

        request.Content = new StringContent(JsonConvert.SerializeObject(restaurantCouponsCreate),Encoding.UTF8,"application/json");

        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<RestaurantCoupons>>(responseString);

        return response!;
    }

    public async Task<Response<RestaurantCoupons>> SetRestaurantCouponActivity(bool isActive, string restaurantId, string couponTypeId)
    {
        await GetRestaurantIdAsync();
        var request = new HttpRequestMessage(HttpMethod.Put,
            $"https://localhost:44329/api/RestaurantCouponControllers/SetRestaurantCouponActivity/{isActive}/{RestaurantId}/{couponTypeId}");

        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<RestaurantCoupons>>(responseString);

        return response!;
    }

    #region Helper Method

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
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Models.ReservationModels;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Services.ReservationServices;

public class ReservationService : IReservationService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenProvider _accessToken;
    private readonly AuthenticationStateProvider _authState;
    private string RestaurantId { get; set; }
    private string Token { get; set; }
    public ReservationService(HttpClient httpClient, IAccessTokenProvider accessToken, AuthenticationStateProvider authState)
    {
        _httpClient = httpClient;
        _accessToken = accessToken;
        _authState = authState;
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

    public async Task<Response<Reservation>> GetReservationsAsync()
    {
        await GetRestaurantIdAsync();
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://localhost:44314/api/Reservation/GetAllValidReservationsForRestaurant/{RestaurantId}");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Reservation>>(responseString);
        return response!;
    }

    public async Task<Response<Reservation>> FindReservationsAsync()
    {
        return new Response<Reservation>();
    }
}
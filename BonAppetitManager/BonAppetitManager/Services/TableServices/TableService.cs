using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Models.ResponseModels;
using Models.TableModels;
using Newtonsoft.Json;
using StaticData;

namespace Services.TableServices;

public class TableService : ITableService
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenProvider _accessToken;
    private readonly AuthenticationStateProvider _authState;

    private string RestaurantId { get; set; }
    private string Token { get; set; }
    public TableService(HttpClient httpClient, AuthenticationStateProvider authState, IAccessTokenProvider accessToken)
    {
        _httpClient = httpClient;
        _authState = authState;
        _accessToken = accessToken;
    }

    public async Task<Response<Table>> GetRestaurantTables()
    {
        await GetRestaurantIdAsync();
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://localhost:44310/api/Table/GetAllRestaurantTable/{RestaurantId}");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Table>>(responseString);
        return response!;
    }

    public async Task<Response<Table>> CreateTableAsync(TableCreate tableToCreate)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44310/api/Table/CreateTable");
        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);
        request.Content = new StringContent(JsonConvert.SerializeObject(tableToCreate), Encoding.UTF8, "application/json");

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Table>>(responseString);
        return response!;
    }

    public async Task<Response<Table>> UpdateTableAsync(TableUpdate tableToUpdate)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44310/api/Table/CreateTable");
        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);
        request.Content = new StringContent(JsonConvert.SerializeObject(tableToUpdate), Encoding.UTF8, "application/json");

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Table>>(responseString);
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
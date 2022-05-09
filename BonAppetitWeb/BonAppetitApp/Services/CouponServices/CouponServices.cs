using Models.CouponTypeModels;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Services.CouponServices;

public class CouponServices : ICouponServices
{
    private readonly HttpClient _httpClient;
    public CouponServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<CouponType>> VerifyRestaurantCouponsForUserAsync(string restaurantId, string applicationUserId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://localhost:44329/api/VerifyCoupon/VerifyCouponActivity/{restaurantId}/{applicationUserId}");

        var client = await _httpClient.SendAsync(request);

        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<CouponType>>(responseString);
        return response!;
    }
}
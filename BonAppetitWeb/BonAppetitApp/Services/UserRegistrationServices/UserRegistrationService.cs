using System.Text;
using Models.ApplicationUserModels;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Services.UserRegistrationServices;

public class UserRegistrationService : IUserRegistrationService
{
    private readonly HttpClient _httpClient;
    public UserRegistrationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<ApplicationUser>> RegisterUserAsync(ApplicationUserCreate applicationUser)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44376/api/RegisterUser/RegisterClient");
        request.Content = new StringContent(JsonConvert.SerializeObject(applicationUser), Encoding.UTF8,"application/json");

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ApplicationUser>>(responseString);
        return response!;
    }
}
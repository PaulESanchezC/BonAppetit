using System.Text;
using Models.ReservationModels;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Services.ReservationServices;

public class ReservationServices : IReservationServices
{
    private readonly HttpClient _httpClient;

    public ReservationServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Reservation>> MakeReservationAsync(ReservationCreateVm reservationToMake)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44314/api/Reservation/MakeReservation");
        request.Content = new StringContent(JsonConvert.SerializeObject(reservationToMake), Encoding.UTF8,
            "application/json");

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Reservation>>(responseString);
        return response!;
    }
}
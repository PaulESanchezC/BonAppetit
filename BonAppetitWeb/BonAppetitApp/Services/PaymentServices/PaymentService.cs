using System.Text;
using Models.PaymentModels;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Services.PaymentServices;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;
    public PaymentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Payment>> CreatePaymentSessionAsync(PaymentCreateVm paymentInformation)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44303/api/Payment/CreatePaymentSession");
        request.Content = new StringContent(JsonConvert.SerializeObject(paymentInformation), Encoding.UTF8,
            "application/json");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Payment>>(responseString);
        return response!;
    }

    public async Task<Response<Payment>> ConfirmPaymentAsync(Payment paymentInformation)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44303/api/Payment/ConfirmPayment");
        request.Content = new StringContent(JsonConvert.SerializeObject(paymentInformation), Encoding.UTF8,
            "application/json");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Payment>>(responseString);
        return response!;
    }
}
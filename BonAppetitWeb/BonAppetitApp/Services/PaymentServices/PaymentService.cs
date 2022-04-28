using System.Text;
using Models.PaymentMessageModels;
using Models.PaymentModels;
using Models.ResponseModels;
using Models.StripeSessionModels;
using Newtonsoft.Json;

namespace Services.PaymentServices;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;
    public PaymentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<StripeSession>> CreatePaymentSessionAsync(StripeSessionCreate paymentInformation)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44303/api/Payment/CreatePaymentSession");
        request.Content = new StringContent(JsonConvert.SerializeObject(paymentInformation), Encoding.UTF8,
            "application/json");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<StripeSession>>(responseString);
        return response!;
    }

    public async Task<Response<Payment>> ConfirmPaymentAsync(PaymentCreateVm paymentInformation, PaymentMessage message)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44303/api/Payment/ConfirmPayment");
        var paymentSuccess = new PaymentSuccess
        {
            PaymentCreate = paymentInformation,
            PaymentMessage = message
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(paymentSuccess), Encoding.UTF8,
            "application/json");

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Payment>>(responseString);
        return response!;
    }
}
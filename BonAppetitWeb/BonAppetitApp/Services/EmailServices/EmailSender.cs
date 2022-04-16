using System.Text;
using Models.EmailModels;
using Models.EmailModels.EmailDataModels;
using Models.EmailModels.EmailReservationModel;
using Models.EmailModels.RestaurantManager;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Services.EmailServices;

public class EmailSender : IEmailSender
{
    private readonly HttpClient _httpClient;
    public EmailSender(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Email>> ClientRegistrationEmailSenderAsync(EmailClient emailClient)
    {
        var data = JsonConvert.SerializeObject(emailClient);
        var email = new Email()
        {
            Action = "client registration",
            Data = data,
            Recipient = emailClient.UserEmail
        };
        var emails = new List<Email>();

        emails.Add(email);
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44360/api/EmailSender/SendEmail");
        request.Content = new StringContent(JsonConvert.SerializeObject(emails), Encoding.UTF8, "application/json");

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Email>>(responseString);
        return response!;
    }

    public async Task<Response<Email>> ReservationEmailSenderAsync(EmailReservation emailReservation, List<string> managersEmails)
    {
        var emails = new List<Email>();

        var reservation = JsonConvert.SerializeObject(emailReservation);
        var emailClient = new Email()
        {
            Action = "reservation client",
            Data = reservation,
            Recipient = emailReservation.Client.UserEmail
        };

        emails.Add(emailClient);

        foreach (var manager in managersEmails)
        {
            var emailManager = new Email()
            {
                Action = "reservation manager",
                Recipient = manager,
                Data = reservation
            };
            emails.Add(emailManager);
        }

        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44360/api/EmailSender/SendEmail");
        request.Content = new StringContent(JsonConvert.SerializeObject(emails), Encoding.UTF8, "application/json");

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Email>>(responseString);
        return response!;
    }
}
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Options;
using Models.ApplicationUserModels;
using Models.EmailModels;
using Models.Options;
using Models.ReservationModels;
using Models.ResponseModels;
using Models.RestaurantModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services.EmailServices.EmailTemplates;

namespace Services.EmailServices;

public class EmailSender : IMailJetEmailSender
{
    private readonly MailjetOptions _mailjetOptions;
    private Response<Email> Response { get; }
    private string Subject { get; set; }
    public EmailSender(IOptions<MailjetOptions> options)
    {
        _mailjetOptions = options.Value;
        Response = new()
        {
            StatusCode = 200,
            IsSuccessful = true,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new()
        };
    }

    public async Task<Response<Email>> MailJetMailSenderAsync(List<Email> emails, CancellationToken cancellationToken)
    {
        var client = new MailjetClient(_mailjetOptions.ApiKey, _mailjetOptions.SecretKey);
        foreach (var email in emails)
        {
            var message = await CreateHtmlMessageTask(email);
            var request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.FromEmail, _mailjetOptions.FromEmail)
             .Property(Send.FromName, _mailjetOptions.FromName)
             .Property(Send.Subject, Subject)
             .Property(Send.HtmlPart, message)
             .Property(Send.Recipients, new JArray {
                new JObject {
                    {"Email", email.Recipient}
                }
             });
            var response = await client.PostAsync(request);
            Console.WriteLine("**********************************************************************************");
            Console.WriteLine($"response => status:{response.StatusCode}; content: {response.Content}");
            Response.ResponseObject!.Add(email);
        }
        return Response;
    }

    public Task<string> CreateHtmlMessageTask(Email email)
    {
        var response = "";
        switch (email.Action.ToLower().Trim())
        {
            case "restaurant registration":
                response = RestaurantRegistrationHtmlBuilder(email.Data);
                Subject = "Restaurant Registration";
                break;
            //TODO: is this needed?
            case "manager registration":
                response = ManagerRegistrationHtmlBuilder(email.Data);
                Subject = "Manager Registration";
                break;
            //TODO: is this needed?
            case "worker registration":
                response = WorkerRegistrationHtmlBuilder(email.Data);
                Subject = "Worker Registration";
                break;
            case "client registration":
                response = ClientRegistrationHtmlBuilder(email.Data);
                Subject = "Client Registration";
                break;
            case "reservation manager":
                response = RestaurantReservationManagerHtmlBuilder(email);
                Subject = "Reservation Manager";
                break;
            case "reservation client":
                response = RestaurantReservationClientHtmlBuilder(email);
                Subject = "Reservation Client";
                break;
            //TODO: is this needed?
            case "test":
                response = EmailTemplate.Test;
                Subject = "Test Client";
                break;
        }
        return Task.FromResult(response);
    }

    private string RestaurantRegistrationHtmlBuilder(string data)
    {
        var restaurant = JsonConvert.DeserializeObject<Restaurant>(data);
        var response = string.Format(EmailTemplate.RestaurantRegistration, restaurant.RestaurantName, restaurant.RestaurantAddress
            , restaurant.RestaurantPhone, restaurant.RestaurantWebsite, restaurant.RestaurantCiy, restaurant.RestaurantCuisineType);
        return response;
    }
    private string ManagerRegistrationHtmlBuilder(string data)
    {
        var manager = JsonConvert.DeserializeObject<RestaurantManager>(data);
        var response = string.Format(EmailTemplate.ManagerRegistration, manager.RestaurantName, manager.RestaurantPhone
            , manager.RestaurantEmail, manager.UserFirstName, manager.UserLastName, manager.UserPhone, manager.UserEmail);
        return response;
    }
    private string WorkerRegistrationHtmlBuilder(string data)
    {
        var worker = JsonConvert.DeserializeObject<RestaurantWorker>(data);
        var response = string.Format(EmailTemplate.WorkerRegistration, worker.RegistrationRestaurantManager.RestaurantName, worker.UserFirstName, worker.UserLastName
        , worker.UserPhone, worker.UserEmail, worker.RegistrationRestaurantManager.UserFirstName, worker.RegistrationRestaurantManager.UserLastName
        , worker.RegistrationRestaurantManager.UserPhone, worker.RegistrationRestaurantManager.UserEmail, worker.RegistrationRestaurantManager.RestaurantPhone
        , worker.RegistrationRestaurantManager.RestaurantEmail);
        return response;
    }
    private string ClientRegistrationHtmlBuilder(string data)
    {
        var client = JsonConvert.DeserializeObject<Client>(data);
        var response = string.Format(EmailTemplate.ClientRegistration, client.UserFirstName, client.UserLastName,
            client.UserPhone, client.UserEmail, client.Coupon);
        return response;
    }
    private string RestaurantReservationManagerHtmlBuilder(Email email)
    {
        var reservation = JsonConvert.DeserializeObject<Reservation>(email.Data);
        var response = string.Format(EmailTemplate.ReservationManager, reservation.OrderId, reservation.TableName, reservation.DateOfReservation, reservation.StartTime
            , reservation.ForHowMany, reservation.Client.UserFirstName, reservation.Client.UserLastName, reservation.Client.UserPhone, reservation.Client.UserEmail);
        return response;
    }
    private string RestaurantReservationClientHtmlBuilder(Email email)
    {
        var reservation = JsonConvert.DeserializeObject<Reservation>(email.Data);
        var response = string.Format(EmailTemplate.ReservationClients, reservation.RestaurantName, reservation.ForHowMany, reservation.DateOfReservation
        , reservation.StartTime, reservation.OrderId, reservation.Client.UserFirstName, reservation.Client.UserLastName, reservation.Client.UserPhone
        , reservation.Client.UserEmail);
        return response;
    }
}
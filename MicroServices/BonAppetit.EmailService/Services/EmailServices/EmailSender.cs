using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Options;
using Models.EmailModels;
using Models.EmailSenderOptionsModels;
using Models.ResponseModels;
using Newtonsoft.Json.Linq;
using Services.EmailServices.EmailTemplates;

namespace Services.EmailServices;

public class EmailSender : IMailJetEmailSender
{
    private readonly MailjetOptions _mailjetOptions;
    private Response<Email> Response { get; }
    public EmailSender(IOptions<MailjetOptions> options)
    {
        _mailjetOptions = options.Value;
        Response = new()
        {
            StatusCode = 200,IsSuccessful = true,Title = "Ok",Message ="Ok",ResponseObject = new()
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
             .Property(Send.Subject, email.Subject)
             .Property(Send.HtmlPart, message)
             .Property(Send.Recipients, new JArray {
                new JObject {
                    {"Email", email.Recipient}
                }
             });
            var response = await client.PostAsync(request);
            Response.ResponseObject!.Add(email);
        }
        return Response;
    }

    public Task<string> CreateHtmlMessageTask(Email email)
    {
        var messageTemplate = "";
        switch (email.Template.ToLower().Trim())
        {
            case "manager":
                messageTemplate = EmailTemplate.ManagerTemplate;
                break;
            case "client":
                messageTemplate = EmailTemplate.ClientTemplate;
                break;
            default:
                messageTemplate = EmailTemplate.RestaurantTemplate;
                break;
        }

        var message = string.Format(messageTemplate, email.Message);
        return Task.FromResult(message);
    }
}
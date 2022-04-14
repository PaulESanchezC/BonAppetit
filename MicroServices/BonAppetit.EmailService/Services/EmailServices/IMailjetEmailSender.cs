using Models.EmailModels;
using Models.ResponseModels;

namespace Services.EmailServices;

public interface IMailJetEmailSender
{
    Task<Response<Email>> MailJetMailSenderAsync(List<Email> emails,CancellationToken cancellationToken);

    Task<string> CreateHtmlMessageTask(Email email);
}
using Models.EmailModels;
using Models.EmailModels.EmailDataModels;
using Models.EmailModels.EmailReservationModel;
using Models.EmailModels.RestaurantManager;
using Models.ResponseModels;

namespace Services.EmailServices;

public interface IEmailSender
{
    Task<Response<Email>> ClientRegistrationEmailSenderAsync(EmailClient emailClient);
    Task<Response<Email>> ReservationEmailSenderAsync(EmailReservation emailReservation, List<string> managers);
}
using Models.EmailModels;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.ReservationModels;

namespace Models.MessageQueueModels.ReservationSuccessModels;

public class ReservationSuccessMessage
{
    public List<Email> Emails { get; set; }
}
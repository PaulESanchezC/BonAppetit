using Models.EmailModels;

namespace Models.MessageQueueModels.ReservationSuccessModels;

public class ReservationSuccessMessage
{
    public List<Email> Emails { get; set; }
}
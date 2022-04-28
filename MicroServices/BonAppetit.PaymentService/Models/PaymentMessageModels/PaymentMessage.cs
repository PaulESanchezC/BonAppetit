using Models.EmailModels;
using Models.ReservationModels;

namespace Models.PaymentMessageModels;

public class PaymentMessage
{
    public ReservationCreate ReservationCreate { get; set; }
    public List<Email> Emails { get; set; }

}
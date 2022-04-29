using Models.EmailModels;
using Models.PaymentModels;
using Models.ReservationModels;

namespace Models.MessageQueueModels.PaymentSuccessMessageModels;

public class PaymentSuccessMessage
{
    public ReservationCreate ReservationCreate { get; set; }
    public PaymentDto Payment { get; set; }
    public string RestaurantEmail { get; set; }
    public string RestaurantName { get; set; }
}
using Models.EmailModels;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.ReservationModels;

namespace Models.MessageQueueModels.ReservationSuccessModels;

public class ReservationSuccessMessage
{
    public List<Email> Emails { get; set; }
    //TODO: Apply changes to other messages models
    public List<int> CouponsCodes { get; set; }
    public string ApplicationUserId { get; set; }
    public string RestaurantId { get; set; }
}
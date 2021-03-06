using Models.CouponTypeModels;
using Models.ReservationModels;

namespace Models.MessageQueueModels.PaymentSuccessMessageModels;

public class PaymentMessage
{
    public ReservationCreate ReservationCreate { get; set; }
    public string RestaurantEmail { get; set; }
    public string RestaurantName { get; set; }
    public List<CouponType> Coupons { get; set; }
}
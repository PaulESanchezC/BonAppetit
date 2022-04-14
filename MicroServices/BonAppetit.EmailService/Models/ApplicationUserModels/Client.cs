using Models.CouponModels;

namespace Models.ApplicationUserModels;

public class Client
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserPhone { get; set; }
    public string UserEmail { get; set; }
    public Coupon Coupon { get; set; }
}
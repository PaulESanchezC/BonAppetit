using Models.CouponModels;

namespace Models.EmailModels.EmailDataModels;

public class EmailClient
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserPhone { get; set; }
    public string UserEmail { get; set; }
    public Coupon Coupon { get; set; }
}
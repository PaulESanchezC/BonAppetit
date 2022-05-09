using System.ComponentModel.DataAnnotations;

namespace Models.CouponPaymentModels;

public class CouponPaymentsCreate
{
    public int CouponCode { get; set; }
}
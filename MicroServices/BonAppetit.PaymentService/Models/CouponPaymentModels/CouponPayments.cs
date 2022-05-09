using System.ComponentModel.DataAnnotations;

namespace Models.CouponPaymentModels;

public class CouponPayments
{
    [Key]
    public int Id { get; set; }

    public int CouponCode { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Models.CouponPaymentModels;

public class CouponPaymentsDto
{
    public int Id { get; set; }
    public int CouponCode { get; set; }
}
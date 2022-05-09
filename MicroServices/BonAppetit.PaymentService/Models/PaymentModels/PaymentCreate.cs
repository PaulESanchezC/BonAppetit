using System.ComponentModel.DataAnnotations;
using Models.CouponTypeModels;

namespace Models.PaymentModels;

public class PaymentCreate
{
    #region Payment properties

    [Required]
    public string RestaurantId { get; set; }

    [Required]
    public string TableId { get; set; }

    public string ApplicationUserId { get; set; }
    [Required]
    public double RestaurantReservationFee { get; set; }

    [Required]
    public double BonAppetitFee { get; set; }

    [Required]
    public double ProvincialTaxes { get; set; }

    [Required]
    public double FederalTaxes { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public string SessionId { get; set; }

    public List<CouponType> Coupons { get; set; }

    #endregion
}
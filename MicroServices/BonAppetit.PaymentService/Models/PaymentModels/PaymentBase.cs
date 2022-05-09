using System.ComponentModel.DataAnnotations;
using Models.CouponTypeModels;

namespace Models.PaymentModels;

public class PaymentBase
{
    #region Payment properties

    [Key]
    public string PaymentId { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string RestaurantId { get; set; }

    [Required]
    public string TableId { get; set; }

    [Required]
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
    
    [Required]
    public List<CouponType> Coupons { get; set; }

    public DateTime DateOfPayment { get; set; } = DateTime.Now;

    #endregion

}
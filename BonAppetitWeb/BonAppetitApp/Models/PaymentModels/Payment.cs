using System.ComponentModel.DataAnnotations;
using Models.CouponPaymentModels;
using Models.CouponTypeModels;

namespace Models.PaymentModels;

public class Payment
{
    #region Payment properties

    public string PaymentId { get; set; }
    public string RestaurantId { get; set; }
    public string TableId { get; set; }
    public string ApplicationUserId { get; set; }
    public double RestaurantReservationFee { get; set; }
    public double BonAppetitFee { get; set; }
    public double ProvincialTaxes { get; set; }
    public double FederalTaxes { get; set; }
    public double Amount { get; set; }
    public List<CouponPayments> Coupons { get; set; }
    public DateTime DateOfPayment { get; set; }

    #endregion
}
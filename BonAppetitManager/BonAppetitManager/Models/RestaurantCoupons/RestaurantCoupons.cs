using System.ComponentModel.DataAnnotations;
using Models.CouponTypeModels;

namespace Models.RestaurantCoupons;

public class RestaurantCoupons
{
    #region Properties

    [Required(AllowEmptyStrings = false)]
    public string RestaurantCouponsId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string CouponTypeId { get; set; }
    public CouponType CouponType { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool IsActive { get; set; }

    #endregion
}
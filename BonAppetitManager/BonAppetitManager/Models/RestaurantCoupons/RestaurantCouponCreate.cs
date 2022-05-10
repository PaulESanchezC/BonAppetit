using System.ComponentModel.DataAnnotations;
using Models.CouponTypeModels;

namespace Models.RestaurantCoupons;

public class RestaurantCouponsCreate
{
    #region Properties

    [Required(AllowEmptyStrings = false)]
    public string CouponTypeId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }

    #endregion
}
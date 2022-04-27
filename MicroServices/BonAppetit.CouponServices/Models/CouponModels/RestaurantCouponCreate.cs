using System.ComponentModel.DataAnnotations;

namespace Models.CouponModels;

public class RestaurantCouponsCreate
{
    #region Properties

    [Required(AllowEmptyStrings = false)]
    public string CouponTypeId { get; set; }
    public CouponType CouponType { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }

    #endregion
}
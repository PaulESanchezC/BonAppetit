using System.ComponentModel.DataAnnotations;

namespace Models.CouponModels;

public class RestaurantCoupons
{
    #region Properties

    [Key]
    public string RestaurantCouponsId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false)]
    public string CouponTypeId { get; set; }
    public CouponType CouponType { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool IsActive { get; set; }

    #endregion

    #region Bussiness properties

    public DateTime DateRequested { get; set; }

    #endregion
}
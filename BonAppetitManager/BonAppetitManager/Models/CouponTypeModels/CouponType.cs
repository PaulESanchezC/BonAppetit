using System.ComponentModel.DataAnnotations;

namespace Models.CouponTypeModels;

public class CouponType
{
    #region CouponType Properties

    [Required(AllowEmptyStrings = false)]
    public string CouponTypeId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int CouponCode { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool IsActive { get; set; }

    #endregion
}
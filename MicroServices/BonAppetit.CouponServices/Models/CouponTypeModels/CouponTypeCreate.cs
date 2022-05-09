using System.ComponentModel.DataAnnotations;

namespace Models.CouponTypeModels;

public class CouponTypeCreate
{
    #region CouponType Properties

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int CouponCode { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool IsActive { get; set; }

    #endregion
}
using System.ComponentModel.DataAnnotations;

namespace Models.CouponTypeModels;

public class CouponType
{

    #region CouponType Properties

    [Key]
    public string CouponTypeId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int CouponCode { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool IsActive { get; set; }

    #endregion

    #region Bussiness Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateDiscontinued { get; set; }

    #endregion
}
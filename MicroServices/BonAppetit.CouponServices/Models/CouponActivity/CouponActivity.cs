using System.ComponentModel.DataAnnotations;

namespace Models.CouponActivity;

public class CouponActivity
{
    #region CouponActivity Properties

    [Key]
    public int CouponActivityId { get; set; }

    [Required]
    public string ApplicationUserId { get; set; }

    [Required]
    public string RestaurantId { get; set; }

    [Required]
    public int CouponCode { get; set; }

    #endregion

    #region Bussiness Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;

    #endregion


}
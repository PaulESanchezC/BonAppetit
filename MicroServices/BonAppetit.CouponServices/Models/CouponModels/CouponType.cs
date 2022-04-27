using System.ComponentModel.DataAnnotations;

namespace Models.CouponModels;

public class CouponType
{
    [Key]
    public string CouponTypeId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int CouponCode { get; set; }

}
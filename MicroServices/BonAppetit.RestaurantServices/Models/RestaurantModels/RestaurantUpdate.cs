using System.ComponentModel.DataAnnotations;
using Models.ImageModels;

namespace Models.RestaurantModels;

public class RestaurantUpdate
{
    #region Restaurant Properties

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantPhone { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantEmail { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantAddress { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantWebsite { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantCiy { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantCuisineType { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double ReservationFee { get; set; }
    #endregion
}
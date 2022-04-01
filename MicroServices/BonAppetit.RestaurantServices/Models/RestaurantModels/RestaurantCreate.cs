using System.ComponentModel.DataAnnotations;
using Models.ImageModels;

namespace Models.RestaurantModels;

public class RestaurantCreate
{
    #region Restaurant Properties

    [Required(AllowEmptyStrings = false)]
    public string RestaurantName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantPhone { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantAddress { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantWebsite { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantCiy { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantCuisineType { get; set; }
    #endregion
}
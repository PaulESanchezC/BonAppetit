using System.ComponentModel.DataAnnotations;
using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

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

    public List<ImageCreate> RestaurantImages { get; set; }
    #endregion
}
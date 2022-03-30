using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Models.RestaurantModels;

public class RestaurantCreate
{
    #region Restaurant Properties

    public string RestaurantName { get; set; } = "";
    public string RestaurantPhone { get; set; } = "";
    public string RestaurantAddress { get; set; } = "";
    public string RestaurantWebsite { get; set; } = "";
    public string RestaurantCiy { get; set; } = "";
    public string RestaurantCuisineType { get; set; } = "";
    #endregion
}
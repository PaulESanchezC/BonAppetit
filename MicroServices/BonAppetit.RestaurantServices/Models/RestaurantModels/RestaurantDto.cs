using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Models.RestaurantModels;

public class RestaurantDto
{
    #region Restaurant Properties
    public string RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantPhone { get; set; }
    public string RestaurantAddress { get; set; }
    public string RestaurantWebsite { get; set; }
    public string RestaurantCiy { get; set; }
    public string RestaurantCuisineType { get; set; }
    public List<ImageDto> Images { get; set; }
    public List<MenuDto> RestaurantMenu { get; set; }
    public List<TableDto> RestaurantTables { get; set; }
    public ScheduleDto RestaurantSchedule { get; set; }
    #endregion
}
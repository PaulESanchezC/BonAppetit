using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Models.RestaurantModels;

public class RestaurantBase
{
    #region Restaurant Properties

    public string RestaurantId { get; set; } = "";
    public string RestaurantName { get; set; } = "";
    public string RestaurantPhone { get; set; } = "";
    public string RestaurantEmail { get; set; }
    public string RestaurantAddress { get; set; } = "";
    public string RestaurantWebsite { get; set; } = "";
    public string RestaurantCiy { get; set; } = "";
    public string RestaurantCuisineType { get; set; } = "";
    public List<ImageBase> RestaurantImages { get; set; }
    public List<MenuBase> RestaurantMenu { get; set; }
    public List<TableBase> RestaurantTables { get; set; }
    public ScheduleBase RestaurantSchedule { get; set; } = new();
    public string ScheduleId { get; set; } = "";
    #endregion


    #region Bussiness Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public int ZonePopularity { get; set; } = 0;
    public bool IsDeleted { get; set; } = false;

    #endregion
}
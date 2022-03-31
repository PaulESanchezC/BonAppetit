using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Models.RestaurantModels;

public class RestaurantBase
{
    #region Restaurant Properties

    public string RestaurantId { get; set; } = Guid.NewGuid().ToString();
    public string RestaurantName { get; set; } = "";
    public string RestaurantPhone { get; set; } = "";
    public string RestaurantAddress { get; set; } = "";
    public string RestaurantWebsite { get; set; } = "";
    public string RestaurantCiy { get; set; } = "";
    public string RestaurantCuisineType { get; set; } = "";
    public List<ImageBase> RestaurantImages { get; set; } = new();
    public List<MenuBase> RestaurantMenu { get; set; } = new();
    public List<TableBase> RestaurantTables { get; set; } = new();
    public ScheduleBase RestaurantSchedule { get; set; } = new();
    public string ScheduleId { get; set; } = "";
    #endregion


    #region Bussiness Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public int ZonePopularity { get; set; } = 0;
    public bool IsDeleted { get; set; } = false;

    #endregion
}
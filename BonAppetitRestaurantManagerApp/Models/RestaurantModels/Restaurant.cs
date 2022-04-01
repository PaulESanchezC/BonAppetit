using System.ComponentModel.DataAnnotations;
using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Models.RestaurantModels;

public class Restaurant
{
    #region Restaurant Properties
    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }

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

    public List<Image> Images { get; set; }
    public List<Menu> RestaurantMenu { get; set; }
    public List<Table> RestaurantTables { get; set; }
    public Schedule RestaurantSchedule { get; set; }
    #endregion
}
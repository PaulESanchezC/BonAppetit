using System.ComponentModel.DataAnnotations;
using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Models.RestaurantModels;

public class RestaurantDto
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

    public List<ImageDto> Images { get; set; }
    public List<MenuDto> RestaurantMenu { get; set; }
    public List<TableDto> RestaurantTables { get; set; }
    public ScheduleDto RestaurantSchedule { get; set; }
    #endregion
}
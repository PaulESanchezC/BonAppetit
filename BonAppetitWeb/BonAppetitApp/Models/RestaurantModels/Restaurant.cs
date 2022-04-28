using System.ComponentModel.DataAnnotations;
using Models.ImageModels;
using Models.MenuModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Models.RestaurantModels;

public class Restaurant
{
    #region Restaurant Properties

    public string RestaurantId { get; set; }

    public string RestaurantName { get; set; }

    public string RestaurantPhone { get; set; }

    public string RestaurantAddress { get; set; }

    public string RestaurantEmail { get; set; }

    public string RestaurantWebsite { get; set; }

    public string RestaurantCiy { get; set; }

    public string RestaurantCuisineType { get; set; }

    public double RestaurantReservationFee { get; set; }

    public List<Image> Images { get; set; }
    public List<Menu> RestaurantMenu { get; set; }
    public List<Table> RestaurantTables { get; set; }
    public Schedule RestaurantSchedule { get; set; }
    #endregion
}
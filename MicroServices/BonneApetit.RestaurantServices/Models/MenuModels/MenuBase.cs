using Models.MenuItemModels;
using Models.RestaurantModels;

namespace Models.MenuModels;

public class MenuBase
{
    #region Menu Properties
    public string MenuId { get; set; } = Guid.NewGuid().ToString();
    public string MenuName { get; set; }
    public string MenuDescription { get; set; }
    public List<MenuItemsBase> MenuItems { get; set; } = new();
    public bool Public { get; set; } = false;

    public RestaurantBase Restaurant { get; set; } = new();
    public string RestaurantId { get; set; } = "";
    #endregion

    #region BussinessProperties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    #endregion
}
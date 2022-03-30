using Models.MenuItemModels;
using Models.RestaurantModels;

namespace Models.MenuModels;

public class MenuCreate
{
    #region Menu Properties
    public string MenuName { get; set; }
    public string MenuDescription { get; set; }
    public List<MenuItemsCreate> MenuItems { get; set; }
    public bool Public { get; set; }
    #endregion
}
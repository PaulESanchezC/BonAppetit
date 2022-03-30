using Models.MenuItemModels;
using Models.RestaurantModels;

namespace Models.MenuModels;

public class MenuDto
{
    #region Menu Properties
    public string MenuId { get; set; }
    public string MenuName { get; set; }
    public string MenuDescription { get; set; }
    public List<MenuItemsDto> MenuItems { get; set; }
    public bool Public { get; set; }
    public RestaurantDto Restaurant { get; set; } = new();
    #endregion
}
using System.ComponentModel.DataAnnotations;
using Models.MenuItemModels;
using Models.RestaurantModels;

namespace Models.MenuModels;

public class Menu
{
    #region Menu Properties
    
    [Required(AllowEmptyStrings = false)]
    public string MenuId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string MenuName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string MenuDescription { get; set; }

    public List<MenuItems> MenuItems { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Public { get; set; }

    [Required(AllowEmptyStrings = false)]
    public Restaurant Restaurant { get; set; } = new();
    #endregion
}
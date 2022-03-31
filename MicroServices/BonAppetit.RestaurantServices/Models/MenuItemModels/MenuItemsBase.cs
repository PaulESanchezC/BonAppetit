using Models.ImageModels;
using Models.MenuModels;

namespace Models.MenuItemModels;

public class MenuItemsBase
{
    #region Menu Items Properties
    public string ItemId { get; set; } = "";
    public string ItemName { get; set; } = "";
    public string Description { get; set; } = "";
    public string CuisineType { get; set; } = "";

    public ImageBase Image { get; set; } = new();
    public string ImageId { get; set; } = "";

    public MenuBase Menu { get; set; }
    public string MenuId { get; set; }
    #endregion

    #region Bussines Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool Public { get; set; } = false;
    #endregion
}
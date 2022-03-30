using Models.ImageModels;

namespace Models.MenuItemModels;

public class MenuItemsDto
{
    #region Menu Items Properties
    public string ItemId { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string CuisineType { get; set; }

    public ImageDto Image { get; set; }
    public string ImageId { get; set; }
    #endregion
}
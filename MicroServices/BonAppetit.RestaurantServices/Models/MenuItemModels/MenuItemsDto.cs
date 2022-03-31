using System.ComponentModel.DataAnnotations;
using Models.ImageModels;
using Models.MenuModels;

namespace Models.MenuItemModels;

public class MenuItemsDto
{
    #region Menu Items Properties
    [Required(AllowEmptyStrings = false)]
    public string ItemId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string ItemName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string CuisineType { get; set; }

    public ImageDto Image { get; set; }
    public string ImageId { get; set; }
    public MenuDto Menu { get; set; }
    public string MenuId { get; set; }
    #endregion
}
using System.ComponentModel.DataAnnotations;
using Models.ImageModels;

namespace Models.MenuItemModels;

public class MenuItemsCreate
{
    #region Menu Items Properties
    [Required(AllowEmptyStrings = false)]
    public string ItemName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string CuisineType { get; set; }
    
    public ImageCreate Image { get; set; }
    
    public string MenuId { get; set; }
    #endregion
}
using System.ComponentModel.DataAnnotations;

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
    #endregion
}
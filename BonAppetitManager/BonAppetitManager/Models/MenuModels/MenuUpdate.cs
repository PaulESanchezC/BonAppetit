using System.ComponentModel.DataAnnotations;
using Models.MenuItemModels;

namespace Models.MenuModels;

public class MenuUpdate
{
    #region Menu Properties
    [Required(AllowEmptyStrings = false)]
    public string MenuName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string MenuDescription { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Public { get; set; }
    #endregion
}
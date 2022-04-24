using System.ComponentModel.DataAnnotations;

namespace Models.ImageModels;

public class ImageUpdate
{
    #region Image Properties

    [Required(AllowEmptyStrings = false)]
    public string ImageIndex { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    #endregion
}
using System.ComponentModel.DataAnnotations;

namespace Models.ImageModels;

public class Image
{
    #region Image Properties
    [Required(AllowEmptyStrings = false)]
    public string ImageId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string ImageIndex { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    public byte[] ImageBytes { get; set; }

    #endregion
}
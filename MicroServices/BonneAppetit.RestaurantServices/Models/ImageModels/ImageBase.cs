using System.ComponentModel.DataAnnotations;

namespace Models.ImageModels;

public class ImageBase
{
    #region Image Properties

    public string ImageId { get; set; } = Guid.NewGuid().ToString();
    public int ImageIndex { get; set; }
    public string Description { get; set; }
    public byte[] ImageBytes { get; set; }

    #endregion

    #region Bussiness Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;

    #endregion
}
namespace Models.ImageModels;

public class ImageDto
{
    #region Image Properties
    public string ImageId { get; set; }
    public string ImageIndex { get; set; }
    public string Description { get; set; }
    public byte[] ImageBytes { get; set; }

    #endregion
}
namespace Models.ImageModels;

public class ImageCreate
{
    #region Image Properties
    public string ImageIndex { get; set; }
    public string Description { get; set; }
    public byte[] ImageBytes { get; set; }
    #endregion
}
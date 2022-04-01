using System.ComponentModel.DataAnnotations;
using Models.ImageModels;

namespace Models.RestaurantModels;

public class RestaurantCreateVm
{
    #region Restaurant Properties

    [Required(AllowEmptyStrings = false)]
    [Display(Name = "Restaurant name")]
    public string RestaurantName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Display(Name = "Phone")]
    public string RestaurantPhone { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Display(Name = "Address")]
    public string RestaurantAddress { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Display(Name = "Website")]
    public string RestaurantWebsite { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Display(Name = "City")]
    public string RestaurantCiy { get; set; }

    [Required(AllowEmptyStrings = false)]
    [Display(Name = "Cuisine")]
    public string RestaurantCuisineType { get; set; }

    [Display(Name = "Images")]
    public List<ImageCreateVm> RestaurantImages { get; set; }
    #endregion
}
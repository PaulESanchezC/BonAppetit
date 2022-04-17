using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.ApplicationUserModels;

namespace Models.RestaurantManagersModels;

public class RestaurantManager
{
    [Key]
    public string RestaurantId { get; set; }

    [Required]
    public string  ApplicationUserId { get; set; }
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }
}
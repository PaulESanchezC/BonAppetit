using System.ComponentModel.DataAnnotations;
using Models.ApplicationUserModels;

namespace Models.ReservationModels;

public class ReservationBase
{
    #region Reservation Properties

    [Key]
    public string ReservationId { get; set; } = Guid.NewGuid().ToString();
    [Required]
    public string RestaurantId { get; set; }
    [Required]
    public string TableId { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    public string OrderId { get; set; }
    [Required]
    public string NoPayment { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    public AnonymousUser? AnonymousUser { get; set; }

    #endregion
}
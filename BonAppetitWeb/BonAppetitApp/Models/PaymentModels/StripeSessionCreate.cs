using System.ComponentModel.DataAnnotations;

namespace Models.StripeSessionModels;

public class StripeSessionCreate
{
    [Required]
    public int TableSeats { get; set; }

    [Required]
    public string RestaurantName { get; set; }

    [Required]
    public double RestaurantReservationFee { get; set; }

    [Required]
    public string RestaurantId { get; set; }
}
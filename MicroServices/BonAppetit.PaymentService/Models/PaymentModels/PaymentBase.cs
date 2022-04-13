using System.ComponentModel.DataAnnotations;

namespace Models.PaymentModels;

public class PaymentBase
{
    [Key]
    public string PaymentId { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string RestaurantId { get; set; }

    [Required]
    public string RestaurantName { get; set; }

    [Required]
    public string TableId { get; set; }

    [Required]
    public int TableSeats { get; set; }

    [Required]
    public string ReservationId { get; set; }

    [Required]
    public int ReservationFor { get; set; }

    [Required]
    public string ApplicationUserId { get; set; }

    [Required]
    public int Amount { get; set; }

    public DateTime DateOfPayment { get; set; }

    public bool IsPayed { get; set; }
}
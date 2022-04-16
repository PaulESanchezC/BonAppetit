using System.ComponentModel.DataAnnotations;

namespace Models.ReservationModels;

public class ReservationCreateVm
{
    #region Reservation Properties

    [Required]
    public string RestaurantId { get; set; }

    [Required]
    public string TableId { get; set; }

    [Required]
    public DateTime DateOfReservation { get; set; }

    [Required]
    public double StartTime { get; set; }

    public string ApplicationUserId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Phone { get; set; }

    [Required(AllowEmptyStrings = false)]
    [EmailAddress]
    public string Email { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string PaymentTransaction { get; set; }
    #endregion
}
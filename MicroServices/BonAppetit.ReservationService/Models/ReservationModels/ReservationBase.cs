using System.ComponentModel.DataAnnotations;

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
    public DateTime DateOfReservation { get; set; }
    [Required]
    public int StartTime { get; set; }

    public int OrderId { get; set; }
    public string ApplicationUserId { get; set; }

    [Required]
    public bool IsUserAnonymous { get; set; }

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

    #region Bussiness Properties

    [Required] public DateTime DateMade { get; set; } = DateTime.Now;

    #endregion
}
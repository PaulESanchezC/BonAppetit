using System.ComponentModel.DataAnnotations;

namespace Models.ReservationModels;

public class ReservationDto
{
    #region Reservation Properties

    [Required]
    public string ReservationId { get; set; }
    [Required]
    public string RestaurantId { get; set; }
    [Required]
    public string TableId { get; set; }
    [Required]
    public DateTime DateOfReservation { get; set; }
    [Required]
    public int StartTime { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public string ApplicationUserId { get; set; }

    public bool IsUserAnonymous { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    #endregion
}
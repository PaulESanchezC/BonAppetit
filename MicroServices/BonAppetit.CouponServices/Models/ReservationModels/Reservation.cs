using System.ComponentModel.DataAnnotations;

namespace Models.ReservationModels;

public class Reservation
{
    #region Reservation Properties

    
    public string ReservationId { get; set; }
    
    public string RestaurantId { get; set; }
    
    public string TableId { get; set; }
    
    public DateTime DateOfReservation { get; set; }
    
    public double StartTime { get; set; }
    
    public int OrderId { get; set; }
    
    public string ApplicationUserId { get; set; }

    public bool IsUserAnonymous { get; set; } = false;
    public string Phone { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    #endregion
}
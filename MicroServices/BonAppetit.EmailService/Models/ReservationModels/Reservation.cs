using Models.ApplicationUserModels;

namespace Models.ReservationModels;

public class Reservation
{
    #region Reservation Properties
    public int OrderId { get; set; }
    public string RestaurantName { get; set; }
    public string TableName { get; set; }
    public DateTime DateOfReservation { get; set; }
    public double StartTime { get; set; }
    public int ForHowMany { get; set; }
    public Client Client { get; set; }

    #endregion
}
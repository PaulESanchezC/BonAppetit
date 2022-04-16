using Models.EmailModels.EmailDataModels;

namespace Models.EmailModels.EmailReservationModel;

public class EmailReservation
{
    #region Reservation Properties
    public int OrderId { get; set; }
    public string RestaurantName { get; set; }
    public string TableName { get; set; }
    public DateTime DateOfReservation { get; set; }
    public int StartTime { get; set; }
    public int ForHowMany { get; set; }
    public EmailClient Client { get; set; }

    #endregion
}
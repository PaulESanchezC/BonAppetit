using Models.ApplicationUserModels;

namespace Models.ReservationModels;

public class ReservationDto
{
    #region Reservation Properties

    public string ReservationId { get; set; }
    public string RestaurantId { get; set; }
    public string TableId { get; set; }
    public DateTime DateTime { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    public AnonymousUser? AnonymousUser { get; set; }

    #endregion
}
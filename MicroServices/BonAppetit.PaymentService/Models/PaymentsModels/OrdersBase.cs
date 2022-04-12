namespace Models.PaymentsModels;

public class OrdersBase
{
    #region Orders Properties

    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public string ApplicationUserId { get; set; }
    public string RestaurantId { get; set; }
    public string TableId { get; set; }
    public string ReservationId { get; set; }
    public double Amount { get; set; }
    public DateTime DateOfPayment { get; set; }
    public DateTime DateOfReservation { get; set; }

    #endregion
}
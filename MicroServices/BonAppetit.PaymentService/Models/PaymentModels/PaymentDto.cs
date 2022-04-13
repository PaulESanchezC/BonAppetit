namespace Models.PaymentModels;

public class PaymentDto
{
    public string PaymentId { get; set; }
    public string RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string TableId { get; set; }
    public int TableSeats { get; set; }
    public string ReservationId { get; set; }
    public int ReservationFor { get; set; }
    public string ApplicationUserId { get; set; }
    public double Amount { get; set; }
    public DateTime DateOfPayment { get; set; }
    public bool IsPayed { get; set; }

    public string PaymentSessionId { get; set; }
}
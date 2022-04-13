namespace Models.PaymentModels;

public class PaymentCreateVm
{
    public string RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string TableId { get; set; }
    public int TableSeats { get; set; }
    public string ApplicationUserId { get; set; }
}
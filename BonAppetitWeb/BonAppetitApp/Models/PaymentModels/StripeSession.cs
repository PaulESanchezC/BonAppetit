namespace Models.StripeSessionModels;

public class StripeSession
{
    public string SessionId { get; set; }
    public double RestaurantFee { get; set; }
    public double BonAppetitFee { get; set; }
    public double ProvincialTaxes { get; set; }
    public double FederalTaxes { get; set; }
    public double Amount { get; set; }
}
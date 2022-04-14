namespace Models.ApplicationUserModels;

public class RestaurantWorker
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserPhone { get; set; }
    public string UserEmail { get; set; }
    public RestaurantManager RegistrationRestaurantManager { get; set; }
}
using Models.ResponseModels;
using Models.RestaurantModels;
using Models.TableReservationBracketsModels;

namespace Services.RestaurantServices;

public interface IRestaurantService
{
    Task<Response<Restaurant>> GetAllRestaurantsAsync();
    Task<Response<Restaurant>> GetSingleRestaurantAsync(string restaurantId);
    Task<Response<TableReservationBracket>> GetAllAvailableReservationBracketsForRestaurant(string restaurantId, string dateOfRequest);
}
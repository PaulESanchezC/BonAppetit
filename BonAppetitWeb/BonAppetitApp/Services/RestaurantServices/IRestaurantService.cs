using Models.ResponseModels;
using Models.RestaurantModels;

namespace Services.RestaurantServices;

public interface IRestaurantService
{
    Task<Response<Restaurant>> GetAllRestaurantsAsync();
    Task<Response<Restaurant>> GetSingleRestaurantAsync(string restaurantId);
}
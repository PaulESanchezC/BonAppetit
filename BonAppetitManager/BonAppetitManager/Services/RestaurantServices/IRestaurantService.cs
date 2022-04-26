using Models.ResponseModels;
using Models.RestaurantModels;

namespace Services.RestaurantServices;

public interface IRestaurantService
{
    Task<Response<Restaurant>> GetRestaurantAsync();
    Task<Response<Restaurant>> CreateRestaurantAsync(RestaurantCreate restaurantToCreate);
    Task<Response<Restaurant>> UpdateRestaurantAsync(RestaurantUpdate restaurantToUpdate);
}
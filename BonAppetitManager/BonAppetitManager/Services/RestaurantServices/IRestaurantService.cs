using Models.ResponseModels;
using Models.RestaurantModels;

namespace Services.RestaurantServices;

public interface IRestaurantService
{
    Task<Response<Restaurant>> GetRestaurantAsync(string restaurantId);
    Task<Response<Restaurant>> CreateRestaurantAsync(RestaurantCreate restaurantToCreate);
}
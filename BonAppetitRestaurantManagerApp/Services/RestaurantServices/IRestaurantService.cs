using Models.ResponseModels;
using Models.RestaurantModels;

namespace Services.RestaurantServices;

public interface IRestaurantService
{
    Task<Response<Restaurant>?> GetRestaurantByIdAsync(string restaurantId);
    Task<Response<Restaurant>?> CreateSingleRestaurant(RestaurantCreateVm restaurantToCreate);
    Task<Response<Restaurant>?> UpdateSingleRestaurant(Restaurant restaurantToUpdate);
    Task<Response<string>> DeleteSingleRestaurant(string restaurantId);
}
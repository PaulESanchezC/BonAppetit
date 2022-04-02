using Models.ResponseModels;
using Models.RestaurantModels;
using Services.ApiRouteProvider;
using Services.HttpClientServices;

namespace Services.RestaurantServices;

public interface IRestaurantService : IHttpClientService<Restaurant>, IApiRouteProvider<Restaurant>
{
    Task<Response<Restaurant>> GetRestaurantByIdAsync(string restaurantId);
    Task<Response<Restaurant>> CreateSingleRestaurant(RestaurantCreateVm restaurantToCreate);
    Task<Response<Restaurant>> UpdateSingleRestaurant(Restaurant restaurantToUpdate);
    Task<Response<string>> DeleteSingleRestaurant(string restaurantId);
}
using System.Net.Http.Json;
using Models.ResponseModels;
using Models.RestaurantModels;
using Services.ApiRouteProvider;
using Services.HttpClientServices;

namespace Services.RestaurantServices;

public class RestaurantService : HttpClientService<Restaurant>, IRestaurantService
{
    public RestaurantService(HttpClient httpClient) : base(httpClient) { }
    
    #region IRestaurantService

    public async Task<Response<Restaurant>> GetRestaurantByIdAsync(string restaurantId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Restaurant>> CreateSingleRestaurant(RestaurantCreateVm restaurantToCreate)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Restaurant>> UpdateSingleRestaurant(Restaurant restaurantToUpdate)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> DeleteSingleRestaurant(string restaurantId)
    {
        throw new NotImplementedException();
    }

    #endregion

    
}
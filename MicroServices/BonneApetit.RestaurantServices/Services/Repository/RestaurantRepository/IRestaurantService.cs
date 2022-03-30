using Models.RestaurantModels;

namespace Services.Repository.RestaurantRepository;

public interface IRestaurantService : IRepository<RestaurantBase,RestaurantDto,RestaurantCreate>
{ }
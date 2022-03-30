using AutoMapper;
using Data;
using Models.RestaurantModels;

namespace Services.Repository.RestaurantRepository;

public class RestaurantService : Repository<RestaurantBase,RestaurantDto,RestaurantCreate>, IRestaurantService
{
    public RestaurantService(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    { }
}
using AutoMapper;
using Models.CouponTypeModels;
using Models.RestaurantCoupons;


namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<CouponTypeDto, CouponType>().ReverseMap();
        CreateMap<CouponType, CouponTypeCreate>().ReverseMap();

        CreateMap<RestaurantCouponsDto, RestaurantCoupons>().ReverseMap();
        CreateMap<RestaurantCouponsCreate, RestaurantCoupons>().ReverseMap();
    }
}
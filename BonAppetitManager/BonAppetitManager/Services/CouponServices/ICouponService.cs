using Models.ResponseModels;
using Models.RestaurantCoupons;

namespace Services.CouponServices;

public interface ICouponService
{
    Task<Response<RestaurantCoupons>> GetRestaurantCoupons();
    Task<Response<RestaurantCoupons>> CreateARestaurantCoupon(RestaurantCouponsCreate restaurantCouponsCreate);
    Task<Response<RestaurantCoupons>> SetRestaurantCouponActivity(bool isActive, string restaurantId, string couponTypeId);

}
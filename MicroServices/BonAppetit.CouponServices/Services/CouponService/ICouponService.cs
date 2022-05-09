using Models.ResponseModels;
using Models.RestaurantCoupons;

namespace Services.CouponService;

public interface ICouponService
{
    Task<Response<RestaurantCouponsDto>> GetRestaurantCouponsAsync(string restaurantId , CancellationToken cancellationToken);
    Task<Response<RestaurantCouponsDto>> CreateRestaurantCouponAsync(RestaurantCouponsCreate couponToCreate, CancellationToken cancellationToken);
    Task<Response<RestaurantCouponsDto>> SetRestaurantCouponToActive(bool isActive, string restaurantId,
        string couponTypeId, CancellationToken cancellationToken);
}
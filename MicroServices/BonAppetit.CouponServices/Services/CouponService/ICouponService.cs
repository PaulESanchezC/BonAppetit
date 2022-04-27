using Models.CouponModels;
using Models.ResponseModels;

namespace Services.CouponServices;

public interface ICouponService
{
    Task<Response<RestaurantCouponsDto>> GetRestaurantCouponsAsync(string restaurantId , CancellationToken cancellationToken);
    Task<Response<RestaurantCouponsDto>> CreateRestaurantCouponAsync(RestaurantCouponsCreate couponToCreate, CancellationToken cancellationToken);
    Task<Response<RestaurantCouponsDto>> SetRestaurantCouponToActive(bool isActive, string restaurantId,
        string couponTypeId, CancellationToken cancellationToken);
}
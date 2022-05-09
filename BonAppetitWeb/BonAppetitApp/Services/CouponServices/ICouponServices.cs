using Models.CouponTypeModels;
using Models.ResponseModels;

namespace Services.CouponServices;

public interface ICouponServices
{
    Task<Response<CouponType>> VerifyRestaurantCouponsForUserAsync(string restaurantId,string applicationUserId);
}
using Models.CouponTypeModels;
using Models.ResponseModels;

namespace Services.VerifyCouponServices;

public interface IVerifyCouponService
{
    Task<Response<CouponTypeDto>> VerifyTransactionCoupon(string applicationUserId, string restaurantId,
        CancellationToken cancellationToken);
}
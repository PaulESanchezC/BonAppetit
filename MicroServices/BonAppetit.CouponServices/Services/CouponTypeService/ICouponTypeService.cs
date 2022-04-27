using Models.CouponModels;
using Models.ResponseModels;

namespace Services.CouponTypeService;

public interface ICouponTypeService
{
    Task<Response<CouponTypeDto>> GetSingleCouponType(string couponTypeId, CancellationToken cancellationToken);
    Task<Response<CouponTypeDto>> GetAllCouponTypes(CancellationToken cancellationToken);
    Task<Response<CouponTypeDto>> CreateCouponType(CouponTypeCreate couponTypeToCreate, CancellationToken cancellationToken);
    Task<Response<CouponTypeDto>> SetCouponTypeToActive(string couponTypeId, bool isActive, CancellationToken cancellationToken);
}
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.CouponTypeModels;
using Models.ResponseModels;
using Models.RestaurantCoupons;

namespace Services.VerifyCouponServices;

public class VerifyCouponService : IVerifyCouponService
{

    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public VerifyCouponService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<CouponTypeDto>> VerifyTransactionCoupon(string applicationUserId, string restaurantId, CancellationToken cancellationToken)
    {
        var coupons = await _db.RestaurantCoupons
            .Include(i => i.CouponType)
            .Where(coupons => coupons.RestaurantId == restaurantId && coupons.IsActive)
            .Select(couponType => couponType.CouponType.CouponCode)
            .ToListAsync(cancellationToken);

        if (!coupons.Any())
            return new Response<CouponTypeDto>
            {
                StatusCode = 400,
                IsSuccessful = false,
                Title = "Empty result",
                Message = "No coupons where found for this restaurant",
                ResponseObject = null
            };

        var clientActivity = await ClientActivity(applicationUserId, restaurantId, coupons, cancellationToken);
        var clientActivityDto = _mapper.Map<List<CouponTypeDto>>(clientActivity);
        
        return clientActivityDto.Any() ?
            new Response<CouponTypeDto>()
            {
                StatusCode = 200,
                IsSuccessful = true,
                Title = "Ok",
                Message = "Ok",
                ResponseObject = clientActivityDto
            }: new Response<CouponTypeDto>
            {
                StatusCode = 400,
                IsSuccessful = false,
                Title = "Empty result",
                Message = "No coupons where found for this restaurant",
                ResponseObject = null
            };
    }

    #region Helper Methods

    private async Task<List<CouponType>?> ClientActivity(string applicationUserId, string restaurantId, List<int> coupons, CancellationToken cancellationToken)
    {
        var activity = await _db.CouponActivities.Where(activity =>
            activity.ApplicationUserId == applicationUserId
            && activity.RestaurantId == restaurantId).ToListAsync(cancellationToken);

        var couponTypeList = new List<CouponType>();
        coupons.ForEach(async coupon =>
        {
            switch (coupon)
            {
                case 1:
                var case1 = activity.Count(item => item.CouponCode == 1);
                if (case1 <= 1)
                    couponTypeList.Add(await _db.CouponTypes.FirstOrDefaultAsync(couponType => couponType.CouponCode == 1, cancellationToken));
                break;

                case 2:
                var case2 = activity.Count(item => item.CouponCode == 2);
                if (case2 == 1)
                    couponTypeList.Add(await _db.CouponTypes.FirstOrDefaultAsync(couponType => couponType.CouponCode == 2, cancellationToken));
                break;

                case 3:
                var case3 = activity.Count(item => item.CouponCode == 3);
                if (case3 == 0)
                    couponTypeList.Add(await _db.CouponTypes.FirstOrDefaultAsync(couponType => couponType.CouponCode == 3, cancellationToken));
                break;
            }
        });
        return couponTypeList;
    }

    #endregion
}
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.ResponseModels;
using Models.RestaurantCoupons;
using Services.CouponService;

namespace Services.CouponServices;

public class CouponService: ICouponService
    
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public CouponService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<RestaurantCouponsDto>> GetRestaurantCouponsAsync(string restaurantId , CancellationToken cancellationToken)
    {
        var restaurantCoupons = await _db.RestaurantCoupons.Include(type => type.CouponType).Where(coupon => coupon.RestaurantId == restaurantId)
            .ToListAsync(cancellationToken);
        if (!restaurantCoupons.Any())
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The operation returned an empty result", null);

        return await ResponseManyBuilderTask(true, 200, "Ok", "Ok", restaurantCoupons);
    }

    public async Task<Response<RestaurantCouponsDto>> CreateRestaurantCouponAsync(RestaurantCouponsCreate couponToCreate, CancellationToken cancellationToken)
    {
        var coupon = _mapper.Map<RestaurantCoupons>(couponToCreate);

        var entity = await _db.RestaurantCoupons.AddAsync(coupon, cancellationToken);
        if (entity.State != EntityState.Added)
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not add the restaurant coupon", null);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not save the restaurant coupon", null);
        }

        return await ResponseSingleBuilderTask(true, 201, "Ok", "Ok", coupon);
    }

    public async Task<Response<RestaurantCouponsDto>> SetRestaurantCouponToActive(bool isActive, string restaurantId, string couponTypeId, CancellationToken cancellationToken)
    {
        var coupon = await _db.RestaurantCoupons.Include(type => type.CouponType)
            .Where(coupon => coupon.RestaurantId == restaurantId && coupon.CouponTypeId == couponTypeId)
            .FirstOrDefaultAsync(cancellationToken);
        if (coupon is null)
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The operation returned an empty result", null);

        coupon.IsActive = isActive;
        var entity = _db.RestaurantCoupons.Update(coupon);
        if (entity.State != EntityState.Modified)
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not add the restaurant coupon", null);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not save the restaurant coupon", null);
        }

        return await ResponseSingleBuilderTask(true, 200, "Ok", "Ok", coupon);
    }

    private Task<Response<RestaurantCouponsDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message, RestaurantCoupons? responseObject)
    {
        var responseObjectDto = new List<RestaurantCouponsDto> { _mapper.Map<RestaurantCouponsDto>(responseObject) };

        var response = new Response<RestaurantCouponsDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }

    private Task<Response<RestaurantCouponsDto>> ResponseManyBuilderTask(bool isSuccessful, int statusCode, string title, string message, List<RestaurantCoupons>? responseObject)
    {
        var responseObjectDto = new List<RestaurantCouponsDto>();
        if (responseObject != null)
            responseObjectDto.AddRange(responseObject.Select(item => _mapper.Map<RestaurantCouponsDto>(item)));

        var response = new Response<RestaurantCouponsDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }
}
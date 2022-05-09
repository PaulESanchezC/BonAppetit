using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.CouponTypeModels;
using Models.ResponseModels;

namespace Services.CouponTypeService;

public class CouponTypeService : ICouponTypeService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public CouponTypeService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<CouponTypeDto>> GetSingleCouponType(string couponTypeId, CancellationToken cancellationToken)
    {
        var coupon = await _db.CouponTypes.Where(coupon => coupon.CouponTypeId == couponTypeId)
            .FirstOrDefaultAsync(cancellationToken);
        if (coupon is null)
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The operation returned an empty result", null);

        return await ResponseSingleBuilderTask(true, 200, "Ok", "Ok", coupon);
    }

    public async Task<Response<CouponTypeDto>> GetAllCouponTypes(CancellationToken cancellationToken)
    {
        var coupons = await _db.CouponTypes.ToListAsync(cancellationToken);
        if (!coupons.Any())
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The operation returned an empty result", null);
        return await ResponseManyBuilderTask(true, 200, "Ok", "Ok", coupons);
    }

    public async Task<Response<CouponTypeDto>> CreateCouponType(CouponTypeCreate couponTypeToCreate, CancellationToken cancellationToken)
    {
        var couponType = _mapper.Map<CouponType>(couponTypeToCreate);

        var entity = await _db.CouponTypes.AddAsync(couponType, cancellationToken);
        if (entity.State != EntityState.Added)
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not add the coupon type", null);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not save the coupon type", null);
        }

        return await ResponseSingleBuilderTask(true, 201, "Ok", "Ok", couponType);
    }

    public async Task<Response<CouponTypeDto>> SetCouponTypeToActive(string couponTypeId, bool isActive, CancellationToken cancellationToken)
    {
        var coupon = await _db.CouponTypes
            .Where(coupon => coupon.CouponTypeId == couponTypeId)
            .FirstOrDefaultAsync(cancellationToken);
        if (coupon is null)
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The operation returned an empty result", null);

        coupon.IsActive = isActive;
        var entity = _db.CouponTypes.Update(coupon);
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

    private Task<Response<CouponTypeDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message, CouponType? responseObject)
    {
        var responseObjectDto = new List<CouponTypeDto> { _mapper.Map<CouponTypeDto>(responseObject) };

        var response = new Response<CouponTypeDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }

    private Task<Response<CouponTypeDto>> ResponseManyBuilderTask(bool isSuccessful, int statusCode, string title, string message, List<CouponType>? responseObject)
    {
        var responseObjectDto = new List<CouponTypeDto>();
        if (responseObject != null)
            responseObjectDto.AddRange(responseObject.Select(item => _mapper.Map<CouponTypeDto>(item)));

        var response = new Response<CouponTypeDto>
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
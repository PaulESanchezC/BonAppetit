using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.RestaurantCoupons;
using Services.CouponService;
using StaticData;

namespace CouponServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantCouponControllers : ControllerBase
    {
        private readonly ICouponService _couponService;
        public RestaurantCouponControllers(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [Authorize(Roles = Role.Manager)]
        [HttpGet("GetRestaurantCoupons/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantCoupons(string restaurantId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _couponService.GetRestaurantCouponsAsync(restaurantId, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [Authorize(Roles = Role.Manager)]
        [HttpPost("CreateRestaurantCoupons")]
        public async Task<IActionResult> CreateRestaurantCoupons([FromBody] RestaurantCouponsCreate restaurantCouponToCreate, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _couponService.CreateRestaurantCouponAsync(restaurantCouponToCreate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [Authorize(Roles = Role.Manager)]
        [HttpPut("SetRestaurantCouponActivity/{isActive:bool}/{restaurantId}/{couponTypeId}")]
        public async Task<IActionResult> SetRestaurantCouponActivity(bool isActive, string restaurantId, string couponTypeId,CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(couponTypeId))
            {
                ModelState.AddModelError("couponTypeId", "The couponTypeId field is required.");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _couponService.SetRestaurantCouponToActive(isActive, restaurantId, couponTypeId, CancellationToken.None);
            return StatusCode(request.StatusCode, request);
        }
    }
}

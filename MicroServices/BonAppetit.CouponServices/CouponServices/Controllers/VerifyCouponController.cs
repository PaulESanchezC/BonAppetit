using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.VerifyCouponServices;

namespace CouponServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyCouponController : ControllerBase
    {
        private readonly IVerifyCouponService _verifyCouponService;
        public VerifyCouponController(IVerifyCouponService verifyCouponService)
        {
            _verifyCouponService = verifyCouponService;
        }

        [HttpGet("VerifyCouponActivity/{restaurantId}/{applicationUserId}")]
        public async Task<IActionResult> VerifyCouponActivity(string restaurantId, string applicationUserId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(applicationUserId))
            {
                ModelState.AddModelError("applicationUserId", "The applicationUserId field is required.");
                return BadRequest(ModelState);
            }

            var request =
                await _verifyCouponService.VerifyTransactionCoupon(applicationUserId, restaurantId, cancellationToken);
            return StatusCode(request.StatusCode,request);
        }
    }
}

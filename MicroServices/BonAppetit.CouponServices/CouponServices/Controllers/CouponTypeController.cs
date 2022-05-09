using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.CouponTypeModels;
using Services.CouponTypeService;
using StaticData;

namespace CouponServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponTypeController : ControllerBase
    {
        private readonly ICouponTypeService _couponType;
        public CouponTypeController(ICouponTypeService couponType)
        {
            _couponType = couponType;
        }

        [HttpGet("GetAllCouponTypes")]
        public async Task<IActionResult> GetAllCouponTypes(CancellationToken cancellationToken)
        {
            var request = await _couponType.GetAllCouponTypes(cancellationToken);
            return StatusCode(request.StatusCode,request);
        }

        [HttpGet("GetSingleCouponType/{couponTypeId}")]
        public async Task<IActionResult> GetSingleCouponType(string couponTypeId ,CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(couponTypeId))
            {
                ModelState.AddModelError("couponTypeId", "The couponTypeId field is required.");
                return BadRequest(ModelState);
            }
            var request = await _couponType.GetSingleCouponType(couponTypeId, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [Authorize(Roles = Role.Developer)]
        [HttpPost("CreateCouponType")]
        public async Task<IActionResult> CreateCouponType([FromBody] CouponTypeCreate couponTypeToCreate,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _couponType.CreateCouponType(couponTypeToCreate, cancellationToken);
            return StatusCode(request.StatusCode,request);
        }

        [Authorize(Roles = Role.Developer)]
        [HttpPut("SetCouponTypeActivity/{couponTypeId}/{isActive}")]
        public async Task<IActionResult> SetCouponTypeActivity(string couponTypeId, bool isActive,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(couponTypeId))
            {
                ModelState.AddModelError("couponTypeId", "The couponTypeId field is required.");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _couponType.SetCouponTypeToActive(couponTypeId,isActive,cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}

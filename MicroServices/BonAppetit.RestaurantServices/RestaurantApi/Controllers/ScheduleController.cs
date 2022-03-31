using Microsoft.AspNetCore.Mvc;
using Models.ScheduleModels;
using Services.Repository.ScheduleRepository;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("GetSingleRestaurantSchedule/{restaurantId}")]
        public async Task<IActionResult> GetSingleRestaurantSchedule(string restaurantId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _scheduleService.GetSingleByAsync(
            schedule => schedule.RestaurantId == restaurantId,
            cancellationToken);

            return StatusCode(request.StatusCode, request);
        }

        [HttpPost("CreateSingleRestaurantSchedule")]
        public async Task<IActionResult> CreateSingleRestaurantSchedule([FromBody] ScheduleCreate scheduleToCreate,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _scheduleService.CreateAsync(scheduleToCreate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpPut("UpdateSingleRestaurantSchedule")]
        public async Task<IActionResult> UpdateSingleRestaurantSchedule([FromBody] ScheduleDto scheduleToUpdate,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _scheduleService.UpdateAsync(scheduleToUpdate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpDelete("DeleteSingleRestaurantSchedule/{scheduleId}")]
        public async Task<IActionResult> DeleteSingleRestaurantSchedule(string scheduleId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(scheduleId))
            {
                ModelState.AddModelError("restaurantId", "The scheduleId field is required.");
                return BadRequest(ModelState);
            }
            var request = await _scheduleService.DeleteAsync(scheduleId, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}

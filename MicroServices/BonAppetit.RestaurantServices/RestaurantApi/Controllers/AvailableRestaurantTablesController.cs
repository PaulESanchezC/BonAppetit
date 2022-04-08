using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.TableTimeBracketsService;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableRestaurantTablesController : ControllerBase
    {
        private readonly ITableTimeBracketService _tableTimeBracketService;
        public AvailableRestaurantTablesController(ITableTimeBracketService tableTimeBracketService)
        {
            _tableTimeBracketService = tableTimeBracketService;
        }

        [HttpGet("GetAllAvailableReservationBracketsForRestaurant/{restaurantId}/{dateOfRequest:datetime}")]
        public async Task<IActionResult> GetAllAvailableReservationBracketsForRestaurant(string restaurantId,
            DateTime dateOfRequest, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            if (dateOfRequest < DateTime.Now)
            {
                ModelState.AddModelError("dateOfRequest", "The dateOfRequest has an invalid value.");
                return BadRequest(ModelState);
            }

            var request = await _tableTimeBracketService.GetAllTableReservationBracketsForRestaurantAsync
                (restaurantId,dateOfRequest,cancellationToken);
            return StatusCode(request.StatusCode, request);

        }
    }
}

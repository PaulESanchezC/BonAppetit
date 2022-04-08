using System.Globalization;
using System.Web;
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

        [HttpGet("GetAllAvailableReservationBracketsForRestaurant/{restaurantId}/{dateOfRequestString}")]
        public async Task<IActionResult> GetAllAvailableReservationBracketsForRestaurant(string restaurantId,
            string dateOfRequestString, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(dateOfRequestString))
            {
                ModelState.AddModelError("dateOfRequestString", "The dateOfRequestString field is required.");
                return BadRequest(ModelState);
            }
            if (!DateTime.TryParseExact(HttpUtility.UrlDecode(dateOfRequestString), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfRequest))
            {
                ModelState.AddModelError("dateOfRequestString", "dateOfRequestString: Invalid date format, the format must be MM-dd-yyyy.");
                return BadRequest(ModelState);
            }
            if (dateOfRequest < DateTime.Now.Date)
            {
                ModelState.AddModelError("dateOfRequest", "The dateOfRequest has an invalid value.");
                return BadRequest(ModelState);
            }

            var request = await _tableTimeBracketService.GetAllTableReservationBracketsForRestaurantAsync
                (restaurantId, dateOfRequest, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}

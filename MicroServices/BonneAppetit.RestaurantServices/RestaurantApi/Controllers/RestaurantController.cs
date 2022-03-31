using Microsoft.AspNetCore.Mvc;
using Models.RestaurantModels;
using Services.Repository.RestaurantRepository;

namespace RestaurantApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet("GetAllRestaurants")]
    public async Task<IActionResult> GetAllRestaurants(CancellationToken cancellationToken)
    {
        var request = await _restaurantService.GetAllByAsync(
            null,
            cancellationToken,
            include => include.RestaurantMenu, include => include.RestaurantImages,
            include => include.RestaurantTables, include => include.RestaurantSchedule);
        return StatusCode(request.StatusCode, request);
    }

    [HttpGet("GetSingleRestaurantById/{restaurantId}")]
    public async Task<IActionResult> GetSingleRestaurant(string restaurantId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(restaurantId))
        {
            ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
            return BadRequest(ModelState);
        }

        var request = await _restaurantService.GetSingleByAsync(
            restaurant => restaurant.RestaurantId == restaurantId,
            cancellationToken,
            include => include.RestaurantMenu, include => include.RestaurantImages,
            include => include.RestaurantTables, include => include.RestaurantSchedule);
        return StatusCode(request.StatusCode, request);
    }

    [HttpPost("CreateSingleRestaurant")]
    public async Task<IActionResult> CreateSingleRestaurant([FromBody] RestaurantCreate restaurantToCreate,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var request = await _restaurantService.CreateAsync(restaurantToCreate, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }

    [HttpPut("UpdateSingleRestaurant")]
    public async Task<IActionResult> UpdateSingleRestaurant([FromBody] RestaurantDto restaurantToUpdate,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var request = await _restaurantService.UpdateAsync(restaurantToUpdate, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }

    [HttpDelete("DeleteSingleRestaurant/{restaurantId}")]
    public async Task<IActionResult> DeleteSingleRestaurant(string restaurantId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(restaurantId))
        {
            ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
            return BadRequest(ModelState);
        }

        var request = await _restaurantService.DeleteAsync(restaurantId, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }
}
using Microsoft.AspNetCore.Mvc;
using Models.MenuItemModels;
using Models.MenuModels;
using Services.Repository.MenuItemRepository;
using Services.Repository.MenuRepository;

namespace RestaurantApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantMenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    private readonly IMenuItemService _menuItemService;
    public RestaurantMenuController(IMenuService menuService, IMenuItemService menuItemService)
    {
        _menuService = menuService;
        _menuItemService = menuItemService;
    }

    [HttpGet("GetAllRestaurantMenus/{restaurantId}")]
    public async Task<IActionResult> GetAllRestaurantMenus(string restaurantId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(restaurantId))
        {
            ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
            return BadRequest(ModelState);
        }

        var request = await _menuService.GetAllByAsync(
            menu => menu.RestaurantId == restaurantId,
            cancellationToken,
            include => include.Restaurant);

        return StatusCode(request.StatusCode, request);
    }

    [HttpGet("GetSingleRestaurantMenu/{menuId}")]
    public async Task<IActionResult> GetSingleRestaurantMenu(string menuId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(menuId))
        {
            ModelState.AddModelError("menuId", "The menuId field is required.");
            return BadRequest(ModelState);
        }

        var request = await _menuService.GetSingleByAsync(
            menu => menu.MenuId == menuId,
            cancellationToken,
            include => include.Restaurant);

        return StatusCode(request.StatusCode, request);
    }

    [HttpPost("CreateRestaurantMenu")]
    public async Task<IActionResult> CreateRestaurantMenu([FromBody] MenuCreate menuToCreate,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var request = await _menuService.CreateAsync(menuToCreate, cancellationToken);

        return StatusCode(request.StatusCode, request);
    }

    [HttpPost("CreateMenuItem")]
    public async Task<IActionResult> CreateMenuItem([FromBody] MenuItemsCreate menuItemToCreate,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var request = await _menuItemService.CreateAsync(menuItemToCreate, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }

    [HttpPost("SetRestaurantMenuPublicValue/{menuId}/{setPublic}")]
    public async Task<IActionResult> SetRestaurantMenuPublicValue(string menuId,
        bool? setPublic, CancellationToken cancellationToken)
    {
        var menuIdValidation = !string.IsNullOrEmpty(menuId);
        var setPublicValidation = setPublic != null;

        if (menuIdValidation is false)
            ModelState.AddModelError("menuId", "The menuId field is required");
        if (setPublicValidation is false)
            ModelState.AddModelError("setPublic", "The setPublic field is required");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var request = await _menuService.SetMenuPublicValueAsync(menuId, (bool)setPublic!, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }

    [HttpPut("UpdateRestaurantMenu")]
    public async Task<IActionResult> UpdateRestaurantMenu([FromBody] MenuDto menuToUpdate,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var request = await _menuService.UpdateAsync(menuToUpdate, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }

    [HttpPut("UpdateMenuItem")]
    public async Task<IActionResult> UpdateMenuItem([FromBody] MenuItemsDto menuItemToUpdate, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var request = await _menuItemService.UpdateAsync(menuItemToUpdate, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }

    [HttpDelete("DeleteRestaurantMenu/{menuId}")]
    public async Task<IActionResult> DeleteRestaurantMenu(string menuId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(menuId))
        {
            ModelState.AddModelError("menuId", "The menuId field is required");
            return BadRequest(ModelState);
        }
        var request = await _menuService.DeleteAsync(menuId, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }

    [HttpDelete("DeleteMenuItem/{menuItemId}")]
    public async Task<IActionResult> DeleteMenuItem(string menuItemId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(menuItemId))
        {
            ModelState.AddModelError("menuItemId","The menuItemId field is required.");
            return BadRequest(ModelState);
        }

        var request = await _menuItemService.DeleteAsync(menuItemId, cancellationToken);
        return StatusCode(request.StatusCode, request);
    }
}

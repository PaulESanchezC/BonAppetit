using Microsoft.AspNetCore.Mvc;
using Models.MenuModels;
using Services.Repository.MenuRepository;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantMenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public RestaurantMenuController(IMenuService menuService)
        {
            _menuService = menuService;
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
                menu=>menu.RestaurantId == restaurantId,
                cancellationToken,
                include=>include.Restaurant);

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
                menu=>menu.MenuId == menuId,
                cancellationToken,
                include=>include.Restaurant);

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

        [HttpPost("SetRestaurantMenuPublicValue/menuId={menuId}/setPublic={setPublic}")]
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

        [HttpDelete("DeleteRestaurantMenu/{menuId}")]
        public async Task<IActionResult> DeleteRestaurantMenu(string menuId, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(menuId))
            {
                ModelState.AddModelError("menuId", "The menuId field is required");
                return BadRequest(ModelState);
            }

            var request = await _menuService.DeleteAsync(menuId, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

    }
}

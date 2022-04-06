using Models.MenuItemModels;
using Models.MenuModels;
using Models.ResponseModels;

namespace Services.MenuServices;

public interface IMenuService
{
    Task<Response<Menu>> GetAllRestaurantMenus(string restaurantId);
    Task<Response<Menu>> GetSingleRestaurantMenu(string menuId);
    Task<Response<Menu>> CreateRestaurantMenu(MenuCreateVm menuToCreate);
    Task<Response<Menu>> CreateMenuItem(MenuItemsCreateVm MenuItemsToCreate);
    Task<Response<Menu>> SetRestaurantMenuPublicValue(string menuId, bool setPublicValue);
    Task<Response<Menu>> UpdateRestaurantMenu(Menu menuToUpdate);
    Task<Response<Menu>> UpdateMenuItem(string restaurantId);
    Task<Response<Menu>> DeleteRestaurantMenu(string menuId);
    Task<Response<Menu>> DeleteMenuItem(string menuItemId);
}
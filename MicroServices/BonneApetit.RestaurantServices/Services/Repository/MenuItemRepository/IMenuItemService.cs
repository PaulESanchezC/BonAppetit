using Models.MenuItemModels;

namespace Services.Repository.MenuItemRepository;

public interface IMenuItemService : IRepository<MenuItemsBase,MenuItemsDto,MenuItemsCreate>
{
    
}
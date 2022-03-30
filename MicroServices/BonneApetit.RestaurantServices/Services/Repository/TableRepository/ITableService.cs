using Models.MenuItemModels;

namespace Services.Repository.TableRepository;

public interface ITableService : IRepository<MenuItemsBase, MenuItemsDto, MenuItemsCreate>
{
    
}
using AutoMapper;
using Data;
using Models.MenuItemModels;

namespace Services.Repository.MenuItemRepository;

public class MenuItemService : Repository<MenuItemsBase, MenuItemsDto, MenuItemsCreate, MenuItemsUpdate>, IMenuItemService
{
    public MenuItemService(ApplicationDbContext db, IMapper mapper) : base(db, mapper) { }
}
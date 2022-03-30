using Models.MenuItemModels;

namespace Services.Repository.ScheduleRepository;

public interface IScheduleService : IRepository<MenuItemsBase, MenuItemsDto, MenuItemsCreate>
{
    
}
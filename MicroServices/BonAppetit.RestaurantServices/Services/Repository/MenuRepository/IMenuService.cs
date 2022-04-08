using Models.MenuItemModels;
using Models.MenuModels;
using Models.ResponseModels;

namespace Services.Repository.MenuRepository;

public interface IMenuService : IRepository<MenuBase, MenuDto, MenuCreate,MenuUpdate>
{
    Task<Response<MenuDto>> SetMenuPublicValueAsync(string menuId, bool setPublic, CancellationToken cancellationToken);
}
using Models.MenuItemModels;
using Models.MenuModels;
using Models.ResponseModels;

namespace Services.Repository.MenuRepository;

public interface IMenuService : IRepository<MenuBase, MenuDto, MenuCreate>
{
    Task<Response<MenuDto>> SetMenuPublicValueAsync(string menuId, bool setPublic, CancellationToken cancellationToken);
}
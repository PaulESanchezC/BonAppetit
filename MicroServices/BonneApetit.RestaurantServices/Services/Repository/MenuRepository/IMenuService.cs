using Models.MenuModels;

namespace Services.Repository.MenuRepository;

public interface IMenuService : IRepository<MenuBase,MenuDto,MenuCreate>{ }
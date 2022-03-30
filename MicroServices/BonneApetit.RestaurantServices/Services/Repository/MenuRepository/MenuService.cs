using AutoMapper;
using Data;
using Models.MenuModels;

namespace Services.Repository.MenuRepository;

public class MenuService : Repository<MenuBase,MenuDto,MenuCreate>, IMenuService
{
    public MenuService(ApplicationDbContext db, IMapper mapper) : base(db, mapper) { }
}
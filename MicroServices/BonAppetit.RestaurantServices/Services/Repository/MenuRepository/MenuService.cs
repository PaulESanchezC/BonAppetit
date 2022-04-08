using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.MenuModels;
using Models.ResponseModels;

namespace Services.Repository.MenuRepository;

public class MenuService : Repository<MenuBase,MenuDto,MenuCreate, MenuUpdate>, IMenuService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public MenuService(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<MenuDto>> SetMenuPublicValueAsync(string menuId, bool setPublic, CancellationToken cancellationToken)
    {
        var dbMenu = await _db.Menus.FirstOrDefaultAsync(menu=>menu.MenuId == menuId, cancellationToken);
        if (dbMenu is null)
            return await ResponseSingleBuilderTask(false, 400, "Operation Failed",
                $"Could not find the menu with the, {menuId}.", null);

        dbMenu!.Public = setPublic;

        var entityState = _db.Update(dbMenu);

        if (entityState.State != EntityState.Modified)
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed",
                $"An error occurred updating the restaurant's menu public status to, {setPublic}, please try again later.", null);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed",
                $"An error occurred saving the restaurant's menu public status to, {setPublic}, please try again later.", null);
        }

        return await ResponseSingleBuilderTask(true, 200, "Ok", "Ok", dbMenu);
    }
}
using AutoMapper;
using Data;
using Models.MenuItemModels;

namespace Services.Repository.TableRepository;

public class TableService : Repository<MenuItemsBase, MenuItemsDto, MenuItemsCreate>, ITableService
{
    public TableService(ApplicationDbContext db, IMapper mapper) : base(db, mapper) { }
}
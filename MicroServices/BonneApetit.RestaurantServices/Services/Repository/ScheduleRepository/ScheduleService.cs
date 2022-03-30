using AutoMapper;
using Data;
using Models.MenuItemModels;

namespace Services.Repository.ScheduleRepository;

public class ScheduleService :Repository<MenuItemsBase, MenuItemsDto, MenuItemsCreate>, IScheduleService
{
    public ScheduleService(ApplicationDbContext db, IMapper mapper) : base(db, mapper) { }
}
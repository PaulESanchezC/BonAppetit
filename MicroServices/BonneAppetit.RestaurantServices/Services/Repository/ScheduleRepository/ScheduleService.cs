using AutoMapper;
using Data;
using Models.MenuItemModels;
using Models.ScheduleModels;

namespace Services.Repository.ScheduleRepository;

public class ScheduleService :Repository<ScheduleBase, ScheduleDto, ScheduleCreate>, IScheduleService
{
    public ScheduleService(ApplicationDbContext db, IMapper mapper) : base(db, mapper) { }
}
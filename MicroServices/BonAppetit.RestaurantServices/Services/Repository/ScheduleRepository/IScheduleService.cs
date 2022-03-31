using Models.ScheduleModels;

namespace Services.Repository.ScheduleRepository;

public interface IScheduleService : IRepository<ScheduleBase, ScheduleDto, ScheduleCreate> { }